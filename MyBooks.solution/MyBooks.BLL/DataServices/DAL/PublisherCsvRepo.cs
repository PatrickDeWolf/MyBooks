using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeneralHelper.Lib;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public static class PublisherCsvRepo
	{

		public static List<IPublisher> GetItems(string file)
		{
			var resultaat = new List<IPublisher>();
			using (StreamReader reader = new StreamReader(file))
			{
				string lijn = reader.ReadLine(); //de regel met velden

				if (lijn != null)
					lijn = reader.ReadLine();

				while (lijn != null)
				{
					var objModel = MaakLijn(lijn);

					if (objModel != null)
						resultaat.Add(objModel);

					lijn = reader.ReadLine(); // lees volgende regel

				} // end while
			}// end using


			return resultaat;
		}

		private static IPublisher MaakLijn(string lijn)
		{
			lijn = lijn.TrimEnd(new char[] { ';' });

			string[] items = lijn.Split(new char[] { ';' });

			if (items.Length < 3)
				return null;

			IPublisher data =
				new PublisherModel
				{
					PublisherId = Convert.ToInt32(items[0]),
					Name = items[1],
					Website = InputValidation.IsFilledIn(items[2]) ? items[2] : "(ONBEKEND)",
					Books = new List<IBook>()

				};

			return data;
		}


	}
}

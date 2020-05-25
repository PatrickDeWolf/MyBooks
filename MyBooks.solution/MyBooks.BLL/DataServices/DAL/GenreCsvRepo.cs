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
	public static class GenreCsvRepo
	{

		public static List<IGenre> GetItems(string file)
		{
			var resultaat = new List<IGenre>();
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

		private static IGenre MaakLijn(string lijn)
		{
			lijn = lijn.TrimEnd(new char[] { ';' });

			string[] items = lijn.Split(new char[] { ';' });

			if (items.Length < 3)// aantal verplichet velden
				return null;

			IGenre data =
				new GenreModel
				{
					GenreId = Convert.ToInt32(items[0]),
					Genre = items[1].ToString(),
					Pictogram = InputValidation.IsFilledIn(items[2]) ? items[2] : "(ONBEKEND)",
				
				};
			return data;
		}


	}
}

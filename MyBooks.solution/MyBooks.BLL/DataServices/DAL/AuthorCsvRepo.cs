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
	public static class AuthorCsvRepo
	{

		public static List<IAuthor> GetItems(string file)
		{
			var resultaat = new List<IAuthor>();
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

		private static IAuthor MaakLijn(string lijn)
		{
			lijn = lijn.TrimEnd(new char[] { ';' });

			string[] items = lijn.Split(new char[] { ';' });

			if (items.Length < 8)
				return null;

			IAuthor data =
				new AuthorModel
				{
					AuthorId = Convert.ToInt32(items[0]),
					Firstname = InputValidation.IsFilledIn(items[1]) ? items[1] : "(ONBEKEND)",
					Lastname = InputValidation.IsFilledIn(items[2]) ? items[2] : "(ONBEKEND)",
					Pseudonym = InputValidation.IsFilledIn(items[3]) ? items[3] : "(ONBEKEND)",
					DateOfBirth = Convert.ToDateTime(items[4]),
					DiedOn = items[5] == "0000-00-00" ? (DateTime?)null : Convert.ToDateTime(items[5]),
					Nationality = items[6],
					Photo = InputValidation.IsFilledIn(items[7]) ? items[7] : "NoImage.png",
					Books =new List<IBook>(),
				};
			return data;
		}

	}//AuthorCsvRepo

}// end namespace

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
	public static class BookCsvRepo
	{
		public static List<IBook> GetItems(string file)
		{
			var resultaat = new List<IBook>();


			try
			{
				if (!File.Exists(file))
				{
					throw new FileNotFoundException($"The file {file} doesn't exists at that location");
				}
				// StreamReader -> een van de mogelijkheden om een tekst bestand uit te lezen
				// using (......) na beëindigen -> Displose() automatisch opgeroepen
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
			catch (IOException ioEx)
			{
				throw new Exception(ioEx.Message);
			}
			catch (Exception ex)
			{
				throw new Exception($"There is a problem");
			}

		}

		private static IBook MaakLijn(string lijn)
		{
			lijn = lijn.TrimEnd(new char[] { ';' });

			string[] items = lijn.Split(new char[] { ';' });

			if (items.Length < 16)
				return null;

			IBook data =
				new BookModel
				{
					BookId = new Guid(items[0]),
					Isbn = items[1],
					Isbn13 = InputValidation.IsFilledIn(items[2]) ? items[2] : "(ONBEKEND)",
					Title = items[3],
					Language = items[4],
					FrontCover= items[5],
					BackCover = items[6],
					Owned = Convert.ToBoolean(Convert.ToInt32(items[7])),
					ReadStatus = (Contracts.ReadStatusEnum)Convert.ToInt32(items[8]),
					Apprectiation = (Contracts.ApprectiationEnum)Convert.ToInt32(items[9]),
					IsEbook = Convert.ToBoolean(Convert.ToInt32(items[10])),
					SerieName = items[11],
					SequenceNumber = Convert.ToInt16(items[12]),
					PublisherId = Convert.ToInt32(items[13]),
					GenreId = Convert.ToInt32(items[14]),
					AuthorId = Convert.ToInt32(items[15]),
				};
			return data;
		}


	} // end CsvHelper

} // end namespace

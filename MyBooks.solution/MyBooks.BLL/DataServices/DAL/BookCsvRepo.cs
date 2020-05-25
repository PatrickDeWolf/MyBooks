using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using GeneralHelper.Lib;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public static class BookCsvRepo
	{
		private static readonly string path = "Data";
		private static readonly string fileName = "Books.csv";
		private static string fullPath = $@"{path}\{fileName}";

		public static List<IBook> GetItems()
		{
			var resultaat = new List<IBook>();
	
			try
			{
				// defensief programming -> check of file exists
				if (!File.Exists(fullPath))
				{
					throw new FileNotFoundException($"The file {fullPath} doesn't exists at that location");
				}
				// StreamReader -> een van de mogelijkheden om een tekst bestand uit te lezen
				// using (......) na beëindigen -> Displose() automatisch opgeroepen
				using (StreamReader reader = new StreamReader(fullPath))
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

		} // end GetItems

		public static void Save(IBook book)
		{
			// Controle of het path bestaat, zo niet aanmaken van de directory
			if (!Directory.Exists((path)))
			{
				Directory.CreateDirectory(path);
			}

			try
			{
				//var test = @"Data\test.txt";
				using (StreamWriter writer =new StreamWriter(fullPath,true))
				{

				//	PropertyInfo[] bookProperties = book.GetType().GetProperties();
					//var record = "";

					//foreach (var prop in bookProperties)
					//{
					//	var value = ConvertToCorrectValue(prop, book);
					//	//var value= prop.GetValue(book, null);
					//	if(value!=null)
					//		record += $"{value};";

					//}
					//writer.WriteLine(record.Remove(record.Length-1));

					//book.prop1+";"+book.prop2+";"+ ......

					var record = Guid.NewGuid().ToString();
					record += $";{book.Isbn}";
					record += $";{book.Isbn13}";
					record += $";{book.Title}";
					record += $";{book.Language}";
					record += $";{book.FrontCover}";
					record += $";{book.BackCover}";
					record += book.Owned ? ";1" : ";0";
					record += $";{(int)book.ReadStatus}";
					record += $";{(int)book.Apprectiation}";
					record += book.IsEbook ? ";1" : ";0";
					record += $";{book.SerieName}";
					record += $";{book.SequenceNumber}";
					record += $";{book.Publisher.PublisherId}";
					record += $";{book.Genre.GenreId}";
					record += $";{book.Author.AuthorId}";

					writer.WriteLine(record);

				}
			}
			catch (IOException ioEx)
			{
				throw new Exception(ioEx.Message);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}


		}// end Save


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


		private static object ConvertToCorrectValue(PropertyInfo propInfo, IBook book)
		{
			var dataType = propInfo.GetValue(book, null).GetType();

			var value = propInfo.GetValue(book, null);

			if (dataType == typeof(AuthorModel))
				return null;
			if (dataType == typeof(PublisherModel))
				return null;
			if (dataType == typeof(GenreModel))
				return null;
			if (dataType == typeof(Contracts.ReadStatusEnum))
				return (int)value;
			if (dataType == typeof(Contracts.ApprectiationEnum))
				return (int)value;
			if (dataType == typeof(bool))
				return (bool)value ? 1 : 0;
			// uncommand when the text values contains a ;
			//if(dataType == typeof(string))
			//	return "\"" + value +"\"";

			return value;
			//return null;
	}

	} // end CsvHelper

} // end namespace

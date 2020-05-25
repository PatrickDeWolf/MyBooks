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
		private static readonly string path = "Data";
		private static readonly string fileName = "Publishers.csv";
		private static string fullPath = $@"{path}\{fileName}";

		public static List<IPublisher> GetItems()
		{
			var resultaat = new List<IPublisher>();
			try
			{
				// defensief programming -> check of file exists
				if (!File.Exists(fullPath))
				{
					throw new FileNotFoundException($"The file {fullPath} doesn't exists at that location");
				}

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

		}

		public static void Save(IPublisher publisher)
		{
			// Controle of het path bestaat, zo niet aanmaken van de directory
			if (!Directory.Exists((path)))
			{
				Directory.CreateDirectory(path);
			}

			try
			{
				publisher.PublisherId = GetNewId();
				using (StreamWriter writer = new StreamWriter(fullPath, true))
				{

					var record = $"{publisher.PublisherId}";
					record += $";{publisher.Name}";
					record += $";{publisher.Website}";

					//	record += $";{publisher.Books}";

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

		}// end SAve





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


		private static int GetNewId()
		{
			var lijst = GetItems();

			var id = 0;

			foreach (var pub in lijst)
			{
				// controle welke id het hoogst is
				id = pub.PublisherId;

			}

			// SELECT Max(PublisherId) FROM Publishers ORDER BY PublisherId

			return id +1;

		}


	}
}

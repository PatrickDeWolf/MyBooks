using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Contracts;

namespace MyBooks.BLL
{

	public class RunTimeDataService : IDataService
	{
		#region Publisher methods
		public void SavePublisher(IPublisher publisher)
		{
			throw new NotImplementedException();
		}

		public async Task<IPublisher> GetPublishers(IPublisher publisher)
		{
			throw new NotImplementedException();
		}

		public async Task<List<IPublisher>> GetPublishers()
		{
			return new List<IPublisher>()
			{
				new PublisherModel
				{
					Name = "Micrsoft Press",
					Website = "http://www.microsoft.be",
					Books = new List<IBook>()
					{
						new BookModel() { Title="OOP: Building Reusable Components With VB.NET",FrontCover = "../Assets/DesignDataImage1.jpg"},
						new BookModel(){Title = " MvvM in Xaramin.Forms", FrontCover = "../Assets/DesignDataImage2.png"}
					}
				},
				new PublisherModel
				{
					Name= "Disney Press",
					Website ="http://www.disney.com",
					Books= new List<IBook>()
					{
						new BookModel{Title="Steamboat Willi"},
						new BookModel { Title = "Tarzan" },
						new BookModel{Title="Star Wars Rebels"}
					}
				}
			};

		} // end GetPublishers

		public void Delete(IPublisher publisher)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Author methods
		public async void SaveAuthor(IAuthor author)
		{

		}

		public async Task<List<IAuthor>> GetAuthors()
		{
			return new List<IAuthor>
			{
				new AuthorModel
				{
					AutherId=1, Firstname="John Roswell",Lastname="Camp",Pseudonym="John Sandford",
					DateOfBirth=new DateTime(),Nationality="USA",Photo="",
					Books=new List<IBook>
										{
												// Guid.NewGuid( ) =  c430ef63-99b9-4c6b-9961-f64c85e15950
											new BookModel{BookId= Guid.NewGuid(),Title= "Kille Woede", FrontCover= "9789400503113.png" },
											new BookModel{BookId= Guid.NewGuid(),Title= "Geschreven in bloed", FrontCover= "9789400504165.png" },
										}
				},
				new AuthorModel
				{
					AutherId=2, Firstname="Steve",Lastname="Berry",Pseudonym="Steve Berry",
					DateOfBirth=new DateTime(),Nationality="USA",Photo="",
					Books=new List<IBook>
									{
										new BookModel{BookId= Guid.NewGuid(),Title= "De erfenis van de Tempeliers", FrontCover= "9789026122590.png" },
									}
				},
			};
		}

		public async Task<List<IAuthor>> GetAuthors(IAuthor author)
		{
			throw new NotImplementedException();
		}

		public void Delete(IAuthor author)
		{

		}



		#endregion


	}// end DesignDataService

}

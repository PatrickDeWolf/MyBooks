using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Contracts;

namespace MyBooks.BLL
{

	public class DesignDataService : IDataService
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
					Name= "VanDuuren",
					Website ="http://www.vanduuren.nl",
					Books= new List<IBook>()
					{
						new BookModel{Title="ASP.NET CORE 3.1"}
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
					AuthorId=1, Firstname="John Roswell",Lastname="Camp",Pseudonym="John Sandford",
					DateOfBirth=new DateTime(),Nationality="USA",Photo="",
					Books=new List<IBook>
					{
						new BookModel{BookId= Guid.NewGuid(),Title= "Kille Woede", FrontCover= "9789400503113.png" },
						new BookModel{BookId= Guid.NewGuid(),Title= "Geschreven in bloed", FrontCover= "9789400504165.png" },
					}
				},
				new AuthorModel
				{
					AuthorId=1, Firstname="Steve",Lastname="Berry",Pseudonym="Steve Berry",
					DateOfBirth=new DateTime(),Nationality="USA",Photo="",
					Books=new List<IBook>
					{
						new BookModel{BookId= Guid.NewGuid(),Title= "De erfenis van de Tempeliers", FrontCover= "9789026122590.png" },
					}
				},
			};
		}

		public async Task<IAuthor> GetAuthor(IAuthor author)
		{
			throw new NotImplementedException();
		}

		public void Delete(IAuthor author)
		{

		}



		#endregion

		#region Gerne methods
		public Task<List<IGenre>> GetGenres()
		{
			throw new NotImplementedException();
		}

		public void SaveGenre(IGenre genre)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Books methods
		public void SaveBook(IBook book)
		{
			throw new NotImplementedException();
		}

		public async Task<List<IBook>> GetBooks()
		{
			return new List<IBook>
			{
				new BookModel{BookId= Guid.NewGuid(),Title= "Kille Woede", FrontCover= "NoImage.png" },//9789400503113
				new BookModel{BookId= Guid.NewGuid(),Title= "Geschreven in bloed", FrontCover= "9789400504165.png" },
				new BookModel{BookId= Guid.NewGuid(),Title= "De erfenis van de Tempeliers", FrontCover= "9789026122590.png" },
			};
		}

		public Task<List<IBook>> GetBooks(IBook book)
		{
			throw new NotImplementedException();
		}

		public Task<List<IBook>> GetBooks(IAuthor author)
		{
			throw new NotImplementedException();
		}

		public Task<List<IBook>> GetBooks(IAuthor author, IGenre genre)
		{
			throw new NotImplementedException();
		}

		public Task<List<IBook>> GetBooks(IPublisher publisher)
		{
			throw new NotImplementedException();
		}

		public Task<List<IBook>> GetBooks(string title)
		{
			throw new NotImplementedException();
		}

		public Task<List<IBook>> GetBooks(IGenre genre)
		{
			throw new NotImplementedException();
		}

		public void Delete(IBook book)
		{
			throw new NotImplementedException();
		}

		#endregion


	}// end DesignDataService


}

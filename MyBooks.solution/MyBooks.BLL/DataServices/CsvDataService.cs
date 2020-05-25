using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using MyBooks.BLL.Messages;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public class CsvDataService:IDataService
	{
		#region Publisher methods
		public void SavePublisher(IPublisher publisher)
		{
			try
			{
				PublisherCsvRepo.Save(publisher);
			}
			catch (Exception ex)
			{
				// Sending a error message of type MVVM Light message
				Messenger.Default.Send<ErrorMessage>(new ErrorMessage { Message = ex.Message });
			}
		}

		public async Task<IPublisher> GetPublishers(IPublisher publisher)
		{
			throw new NotImplementedException();
		}


		public async Task<List<IPublisher>> GetPublishers()
		{
			//	var publishers = PublisherCsvRepo.GetItems(@"Data\Publishers.csv");
			//return publishers; //PublisherCsvRepo.GetItems(@"Data\Publishers.csv");

			return PublisherCsvRepo.GetItems(); // \t -> Tab \n -> new line

		} // end GetPublishers

		public void Delete(IPublisher publisher)
		{
			throw new NotImplementedException();
		}

		#endregion		#region Publisher methods

		#region Gerne methods

		public async Task<List<IGenre>> GetGenres()
		{
			return GenreCsvRepo.GetItems(@"Data\Genres.csv");
		}

		public void SaveGenre(IGenre genre)
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
			return AuthorCsvRepo.GetItems(@"Data\Authors.csv");
		}

		public async Task<IAuthor> GetAuthor(IAuthor author)
		{
			var authors = await GetAuthors();
		
			return authors.FirstOrDefault(record => record.AuthorId == author.AuthorId);

		}


		public void Delete(IAuthor author)
		{

		}


		#endregion

		#region Books methods
		public void SaveBook(IBook book)
		{
			// het opslaan van een boek
			try
			{
				
				BookCsvRepo.Save(book);

				Messenger.Default.Send<BookMessage>(new BookMessage{BookItem=book});

			}
			catch (Exception ex)
			{
				// Sending a error message of type MVVM Light message
				Messenger.Default.Send<ErrorMessage>(new ErrorMessage{Message = ex.Message});
				//throw;
			}
		}

		public async Task<List<IBook>> GetBooks()
		{
			var books = BookCsvRepo.GetItems();

			var authors = await GetAuthors();
			var publishers = await GetPublishers();
			var genres = await GetGenres();


			foreach (var book in books)
			{
				book.Publisher = publishers.FirstOrDefault(record => record.PublisherId == book.PublisherId);
				book.Genre = genres.FirstOrDefault(record => record.GenreId == book.GenreId);
				book.Author = authors.FirstOrDefault(record => record.AuthorId == book.AuthorId);
			}
			
			return books;
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




	} // end CsvDataService

}

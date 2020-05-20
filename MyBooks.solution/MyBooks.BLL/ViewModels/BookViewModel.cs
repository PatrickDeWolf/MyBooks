using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public class BookViewModel : ViewModelBase
	{
		private IDataService _dataService;

		public string PageTitle => "Book";




		// Boek
		// lijsten van Genre, Publisher, Author

		#region The object properties
		private IBook _book;
		public IBook Book
		{
			get
			{
				return _book ?? (_book = new BookModel());
			}
			set
			{
				if (_book == value)
					return;

				_book = value;
				RaisePropertyChanged();
			}
		}// end Book

		// Author objects
		private IAuthor _selectedAutor;
		public IAuthor SelectedAuthor
		{
			get
			{
				return _selectedAutor ?? (_selectedAutor = new AuthorModel());
			}
			set
			{
				if (_selectedAutor == value)
					return;

				_selectedAutor = value;
				RaisePropertyChanged();
			}
		}// end SelectedAuthor

		private List<IAuthor> _authors;
		public List<IAuthor> Authors
		{
			get
			{
				return _authors ?? (_authors = Authors);
			}
			set
			{
				if (_authors == value)
					return;

				_authors = value;
				RaisePropertyChanged();
			}
		}// end Authors

		// Publisher Objects
		private IPublisher _selectedPublisher;
		public IPublisher SelectedPublisher
		{
			get
			{
				return _selectedPublisher ?? (_selectedPublisher = new PublisherModel());
			}
			set
			{
				if (_selectedPublisher == value)
					return;

				_selectedPublisher = value;
				RaisePropertyChanged();
			}
		}// end SelectedPublisher

		private List<IPublisher> _publishers;
		public List<IPublisher> Publishers
		{
			get
			{
				return _publishers ?? (_publishers = new List<IPublisher>());
			}
			set
			{
				if (_publishers == value)
					return;

				_publishers = value;
				RaisePropertyChanged();
			}
		}// end Publishers 

		// Gerne objects
		private IGenre _selectedGenre;
		public IGenre SelectedGenre
		{
			get => _selectedGenre ?? (_selectedGenre = new GerneModel());
			set
			{
				if (_selectedGenre == value)
					return;

				_selectedGenre = value;
				RaisePropertyChanged();
			}
		}// end SelectedGenre

		private List<IGenre> _genres;
		public List<IGenre> Genres
		{
			get => _genres ?? (_genres = new List<IGenre>());
			set
			{
				if (_genres == value)
					return;

				_genres = value;
				RaisePropertyChanged();
			}
		}// end Genres

		#endregion

		#region ICommands
		public ICommand SaveCommand
		{
			get
			{
				//return new RelayCommand(() => _dataService.SaveBook(Book));
				return new RelayCommand(Save);
			}
		}
		#endregion

		public BookViewModel(IDataService dataService)
		{
			_dataService = dataService;
	

			GetData();
		}

		// Opdracht Save, 
		// nHet ovullen van de nodige collecties
		private async void GetData()
		{
			Publishers = await _dataService.GetPublishers();
			Authors = await _dataService.GetAuthors();
			Genres = await _dataService.GetGenres();

		}//end GetData

		private void Save()
		{
			Book = new BookModel
			{
				BookId = Guid.NewGuid(),
				Isbn = "N.A.",
				Isbn13 = "1234567890123",
				Title = "Joepie bijna C#9",
				Language = "NL",
				FrontCover = "NoImage.png",
				BackCover = "NoImage.png",
				Owned = false,
				ReadStatus = Contracts.ReadStatusEnum.Unread,
				Apprectiation = Contracts.ApprectiationEnum.VeryBAd,
				IsEbook = true,
				SerieName = "N.A.",
				SequenceNumber = 0,
				Publisher = new PublisherModel {PublisherId = 1},
				Genre = new GerneModel {GenreId = 1},
				Author = new AuthorModel {AuthorId = 1},
				PublisherId = 1,
				GenreId = 1,
				AuthorId = 1
			};
			_dataService.SaveBook(Book);
		}


	}// end BookViewModel

}

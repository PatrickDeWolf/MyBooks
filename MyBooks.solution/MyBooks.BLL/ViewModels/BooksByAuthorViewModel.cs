using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DannyVN.Library;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyBooks.BLL.Messages;
using MyBooks.Contracts;

namespace MyBooks.BLL.ViewModels
{
	public class BooksByAuthorViewModel : ViewModelBase
	{
		private IDataService _dataService;

		private INavigationService<NavigationPageEnum> _navigationService;

		public string PageTitle => "Authors and their books";

		// The TreeView
		private ObservableCollection<IAuthor> _authors;
		public ObservableCollection<IAuthor> Authors
		{
			get
			{
				return _authors ?? (_authors = new ObservableCollection<IAuthor>());
			}
			set
			{
				if (_authors == value)
					return;

				_authors = value;
				RaisePropertyChanged();
			}
		}// end Authors

		// Wrappanel met alle boeken
		private ObservableCollection<IBook> _books;
		public ObservableCollection<IBook> Books
		{
			get
			{
				return _books ?? (_books = new ObservableCollection<IBook>());
			}
			set
			{
				if (_books == value)
					return;

				_books = value;
				RaisePropertyChanged();
			}
		}// end Books
		private IBook _selectedBook;
		public IBook SelectedBook
		{
			get
			{
				return _selectedBook;
			}
			set
			{
				if (_selectedBook == value)
					return;

				_selectedBook = value;
				RaisePropertyChanged();
			}
		}// end SelectedBook


		// ICommands

		// EditBookCommand -> Send MVVM Message with selectedBook + navigate to BookView
		public ICommand EditBookCommand
		{
			get
			{
				return new RelayCommand(() =>
				{
					
					_navigationService.NavigateTo(NavigationPageEnum.BookView);
					Messenger.Default.Send<BookMessage>(new BookMessage { BookItem = SelectedBook });

					////var books = Books.;
					//var boek = Books.FirstOrDefault(book => book.Title == SelectedBook.Title);
					//boek.Title += " Ikke";

					//Books[Books.IndexOf(SelectedBook)] = boek;

				});

			}
		}// end EditBookCommand

		public BooksByAuthorViewModel(IDataService dataService, INavigationService<NavigationPageEnum> navigationService)
		{
			_dataService = dataService;

			_navigationService = navigationService;

			GetData();

		}


		private async void GetData()
		{
			// ophalen van de collectie van auteurs
			var authors = await _dataService.GetAuthors();

			// sorteren van de lijst op het veld Pseudonym
			Authors = new ObservableCollection<IAuthor>(authors.OrderBy(field => field.Pseudonym));

			var books = await _dataService.GetBooks();
			Books = new ObservableCollection<IBook>(books.OrderBy(field => field.Genre.Genre));

			foreach (var author in Authors)
			{
				author.Books = books.Where(record => record.AuthorId == author.AuthorId).ToList();
			}

		}


	}//end BooksByAuthorViewModel
} //end namespace

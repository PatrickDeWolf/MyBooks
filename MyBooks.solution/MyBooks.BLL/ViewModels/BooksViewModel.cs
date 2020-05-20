using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyBooks.BLL.Messages;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public class BooksViewModel:ViewModelBase
	{
		private IDataService _dataService;
		public string PageTitle => "Books";

		private  ObservableCollection<IBook> localBooks;

		private string _errorMessage;
		public string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				if (_errorMessage == value)
					return;

				_errorMessage = value;
				RaisePropertyChanged();
			}
		}// end ErrorMessage

		//List of all authors
		private List<IAuthor> _authors; //_authorList - _listOfAuthors
		public List<IAuthor> Authors
		{
			get
			{
				return _authors ?? (_authors=new List<IAuthor>());
			}
			set
			{
				if (_authors == value) return;

				_authors = value;
				RaisePropertyChanged();
			}

		}// end Authors

		private IAuthor _selectedAuthor;
		public IAuthor SelectedAuthor
		{
			get
			{
				return _selectedAuthor??(_selectedAuthor=new AuthorModel());
			}
			set
			{
				if (_selectedAuthor == value) return;

				_selectedAuthor = value;
				RaisePropertyChanged();

			}
		}// end SelectedAuthor


		// List of all books
		private ObservableCollection<IBook> _books;
		public ObservableCollection<IBook> Books
		{
			get
			{
				return _books??(_books=new ObservableCollection<IBook>());
			}
			set
			{
				if (_books == value) return;

				_books = value;
				RaisePropertyChanged();
			}
		}// end Books

		// MVVM Commands

		public ICommand GetBookByAuthorCommand
		{
			get
			{
				// () => LAMDA of naamloze methode
				return new RelayCommand( ()=>
				{
					Books = new ObservableCollection<IBook>(localBooks);
					if (SelectedAuthor.AuthorId > 0)
					{
						var result = localBooks.Where(book => book.AuthorId == SelectedAuthor.AuthorId).ToList();
						Books = new ObservableCollection<IBook>(result);
					}
				});
			}
		} // end GetBookByAuthorCommand


		//public ICommand GetBookByAuthorCommand
		//{
		//	get
		//	{
		//		return new RelayCommand(GetBooksByAuthor);
		//	}
		//}


		public BooksViewModel(IDataService dataService)
		{
			_dataService = dataService;

			// registration of the Messages
			Messenger.Default.Register<ErrorMessage>
				(
					this,msg => ErrorMessage=msg.Message
				);

			Messenger.Default.Register<BookMessage>
				(
					this, boek =>
					{
						Books.Add(boek.BookItem);
						localBooks.Add(boek.BookItem);
					});


			GetData();

		}


		// the methods

		private async void GetData()
		{
			//Docent: tussen Try Catch en verzenden errorMessage in the Catch
			Authors = await _dataService.GetAuthors();
			Authors.Insert(0,new AuthorModel{AuthorId = 0,Pseudonym = "All"});

			Books = new ObservableCollection<IBook>( await _dataService.GetBooks());

			localBooks= new ObservableCollection<IBook>(Books);

		}

		private async void GetBooksByAuthor()
		{
			// Pas de lijst van boeken aan op basis van de geselecteerde auteur - SelectedAuthor

			// Hoe beperken op basis van Auteur?
			// de databron is een Collection object --> LINQ 2 Objects
			// de databron is een XML document			--> LINQ 2 XML
			// de databron is een MS SQLServer			--> LINQ 2 SQL 
			// de databron is een Database					--> SQL statements
			// de databron is een database vie EF		--> LINQ Language INtergrated Query
			Books = localBooks;
			//if (SelectedAuthor.AuthorId > 0)
			//{

			//	//LINQ
			//var query = (from book in localBooks
			//							where book.AuthorId == SelectedAuthor.AuthorId
			//							select book).ToList();

			//Books = query;
		
			//}

			// LINQ + Lamba expression -> Naamloze methode
			if (SelectedAuthor.AuthorId>0)
			{
				Books = new ObservableCollection<IBook>(localBooks.Where(book => book.AuthorId == SelectedAuthor.AuthorId).ToList());
			}

		}

	}// end BooksViewModel

}// end namespace

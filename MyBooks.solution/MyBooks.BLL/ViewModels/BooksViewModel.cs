using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public class BooksViewModel:ViewModelBase
	{
		private IDataService _dataService;


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
		private List<IBook> _books;
		public List<IBook> Books
		{
			get
			{
				return _books??(_books=new List<IBook>());
			}
			set
			{
				if (_books == value) return;

				_books = value;
				RaisePropertyChanged();
			}
		}// end Books




		public BooksViewModel(IDataService dataService)
		{
			_dataService = dataService;

			GetData();

		}


		// the methods

		private async void GetData()
		{
			Authors = await _dataService.GetAuthors();

			Books = await _dataService.GetBooks();

		}

		private async void GetBooksByAuthor()
		{
			// Pas de lijst van boeken aan op basis van de geselecteerde auteur - SelectedAuthor

			// Hoe beperken op basis van Auteur?
			// de databron is een Collection object --> LINQ 2 Objects
			// de databron is een XML document			--> LINQ 2 XML
			// de databron is een MS SQLServer			--> LINQ 2 SQL 
			// de databron is een Database					--> SQL statements
			// de databron is een database vie EF		--> LINQ 

		}

	}// end BooksViewModel

}// end namespace

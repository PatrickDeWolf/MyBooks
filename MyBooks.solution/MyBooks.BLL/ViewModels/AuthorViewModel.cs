using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using MyBooks.Contracts;

namespace MyBooks.BLL.ViewModels
{
	/// <summary>
	/// 
	/// </summary>
	public class AuthorViewModel:ViewModelBase
	{
		private IDataService _dataService;

		public string PageTitle { get { return "Author"; } }


		private AuthorModel _author;
		public AuthorModel Author
		{
			get
			{
				return _author??(_author= new AuthorModel());
			}
			set
			{
				if (_author == value) return;

				_author = value;
				RaisePropertyChanged();
			}
		}// end Author

		//private List<BookModel> _books;
		//public List<BookModel> Books
		//{
		//	get
		//	{
		//		return _books??(_books=new List<BookModel>());
		//	}
		//	set
		//	{
		//		if (_books == value) return;

		//		_books = value;
		//		RaisePropertyChanged();
		//	}
		//}// end Books



		// The command

		public AuthorViewModel(IDataService dataService)
		{
			_dataService = dataService;

			Author = new AuthorModel { Firstname = "Danny" };
		}

		private async void GetBooks()
		{

		//	_books=new List<BookModel>();
		}



	} // end AuthorViewModel

} // end namespace

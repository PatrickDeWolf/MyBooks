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
	public class AuthorViewModel : ViewModelBase
	{
		private IDataService _dataService;

		public string PageTitle => "Author";


		private AuthorModel _author;
		public AuthorModel Author
		{
			get
			{
				return _author ?? (_author = new AuthorModel());
			}
			set
			{
				if (_author == value) return;

				_author = value;
				RaisePropertyChanged();
			}
		}// end Author

		
		// The command

		public AuthorViewModel(IDataService dataService)
		{
			_dataService = dataService;

			GetData();
		}


		private async void GetData()
		{
			var result = await _dataService.GetAuthors();
			Author = result[0] as AuthorModel;
		}



	} // end AuthorViewModel

} // end namespace

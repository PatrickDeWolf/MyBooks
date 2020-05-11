using System;
using System.Collections.Generic;
using System.Text;
using MyBooks.Contracts;


namespace MyBooks.BLL
{
	public class BookModel : ModelBase, IBook 
	{ 
		private string _title;

		public string Title
		{
			get { return _title; }
			set
			{
				if (_title == value) return;
				_title = value;
				RaisePropertyChanged();
			}
		}

		private string _frontcover;
		public string FrontCover
		{
			get
			{
				return _frontcover;
			}
			set
			{
				if (_frontcover == value) return;

				_frontcover = value;
				RaisePropertyChanged();
			}
		}// end FrontCover




		
	} // end BookModel

} // end namespace

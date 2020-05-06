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


		private string _frontCover;
		public string FrontCover
		{
			get
			{
				return _frontCover;
			}
			set
			{
				if (_frontCover == value) return;

				_frontCover = value;
				RaisePropertyChanged();
			}
		}// end FrontCover


		public override string ToString()
		{
			//return base.ToString();
			return Title;

		}


	} // end BookModel

} // end namespace

using System;
using System.Collections.Generic;
using System.Text;
using MyBooks.Contracts;


namespace MyBooks.BLL
{
	public class BookModel : ModelBase, IBook
	{
		private Guid _bookId;
		public Guid BookId
		{
			get
			{
				return _bookId;
			}
			set
			{
				if (_bookId == value) return;

				_bookId = value;
				RaisePropertyChanged();
			}
		}// end BookId


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

		//private Contracts.ReadStatusEnum _readStatus;
		//public Contracts.ReadStatusEnum ReadStatus
		//{
		//	get
		//	{
		//		return _readStatus;
		//	}
		//	set
		//	{
		//		if (_readStatus == value) return;

		//		_readStatus = value;
		//		RaisePropertyChanged();
		//	}
		//}// end ReadStatusEnum

		//private Contracts.ApprectiationEnum _apprectiation;
		//public Contracts.ApprectiationEnum Apprectiation
		//{
		//	get
		//	{
		//		return _apprectiation;
		//	}
		//	set
		//	{
		//		if (_apprectiation == value) return;

		//		_apprectiation = value;
		//		RaisePropertyChanged();
		//	}
		//}// end Apprectiation




	} // end BookModel

} // end namespace

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GeneralHelper.Lib;
using MyBooks.Contracts;


namespace MyBooks.BLL
{
	public class BookModel : ModelBase, IBook, IDataErrorInfo
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
				if (_bookId == value)
					return;

				_bookId = value;
				RaisePropertyChanged();
			}
		}// end BookId

		private string _Isbn;
		public string Isbn
		{
			get
			{
				return _Isbn;
			}
			set
			{
				if (_Isbn == value)
					return;

				_Isbn = value;
				RaisePropertyChanged();
			}
		}// end Isbn

		private string _Isbn13;
		public string Isbn13
		{
			get
			{
				return _Isbn13;
			}
			set
			{
				if (_Isbn13 == value)
					return;

				_Isbn13 = value;
				RaisePropertyChanged();
			}
		}// end Isbn13

		private string _title;
		public string Title
		{
			get
			{
				return _title;
			}
			set
			{
				if (_title == value)
					return;
				_title = value;
				RaisePropertyChanged();
			}
		}

		private string _language;
		public string Language
		{
			get
			{
				return _language;
			}
			set
			{
				if (_language == value)
					return;

				_language = value;
				RaisePropertyChanged();
			}
		}// end Language

		private string _frontcover="NoImage.png";
		public string FrontCover
		{
			get
			{
				return _frontcover;
			}
			set
			{
				if (_frontcover == value)
					return;

				_frontcover = value;
				RaisePropertyChanged();
			}
		}// end FrontCover

		private string _backCover="NoImage.png";
		public string BackCover
		{
			get
			{
				return _backCover;
			}
			set
			{
				if (_backCover == value)
					return;

				_backCover = value;
				RaisePropertyChanged();
			}
		}// end BackCover

		private bool _owned;
		public bool Owned
		{
			get
			{
				return _owned;
			}
			set
			{
				if (_owned == value)
					return;

				_owned = value;
				RaisePropertyChanged();
			}
		}// end Owned

		private Contracts.ReadStatusEnum _readStatus;
		public Contracts.ReadStatusEnum ReadStatus
		{
			get
			{
				return _readStatus;
			}
			set
			{
				if (_readStatus == value)
					return;

				_readStatus = value;
				RaisePropertyChanged();
			}
		}// end ReadStatusEnum

		private Contracts.ApprectiationEnum _apprectiation;
		public Contracts.ApprectiationEnum Apprectiation
		{
			get
			{
				return _apprectiation;
			}
			set
			{
				if (_apprectiation == value)
					return;

				_apprectiation = value;
				RaisePropertyChanged();
			}
		}// end Apprectiation

		private bool _isEbook;
		public bool IsEbook
		{
			get
			{
				return _isEbook;
			}
			set
			{
				if (_isEbook == value)
					return;

				_isEbook = value;
				RaisePropertyChanged();
			}
		}// end IsEbook

		private string _serieName;
		public string SerieName
		{
			get
			{
				return _serieName;
			}
			set
			{
				if (_serieName == value)
					return;

				_serieName = value;
				RaisePropertyChanged();
			}
		}// end SerieName

		private short _sequenceNumber;
		public short SequenceNumber

		{
			get
			{
				return _sequenceNumber;
			}
			set
			{
				if (_sequenceNumber == value)
					return;

				_sequenceNumber = value;
				RaisePropertyChanged();
			}
		}// end SequenceNumber

		private IPublisher _publisher;
		public IPublisher Publisher
		{
			get
			{
				return _publisher ?? (_publisher = new PublisherModel());
			}
			set
			{
				if (_publisher == value)
					return;

				_publisher = value;
				RaisePropertyChanged();
			}
		}// end Publisher

		private IGenre _genre;
		public IGenre Genre
		{
			get
			{
				return _genre ?? (_genre = new GenreModel());
			}
			set
			{
				if (_genre == value)
					return;

				_genre = value;
				RaisePropertyChanged();
			}
		}// end Gerne

		private IAuthor _author;
		public IAuthor Author
		{
			get
			{
				return _author ?? (_author = new AuthorModel());
			}
			set
			{
				if (_author == value)
					return;

				_author = value;
				RaisePropertyChanged();
			}
		}// end Author

		//Alleen voor csv en Database bestanden
		public int PublisherId
		{
			get; set;
		}
		public int GenreId
		{
			get; set;
		}
		public int AuthorId
		{
			get; set;
		}

		public string this[string columnName]
		{
			get
			{
	
				switch (columnName)
				{
					case nameof(Title):
						if (!InputValidation.IsFilledIn(Title))
						{
							return $"The {columnName} is a required field";
						}
						break;

					case nameof(Language):
						if (!InputValidation.IsFilledIn(Language))
						{
							return $"The {columnName} is a required field";
						}
						break;

					case nameof(Isbn13):
						if (InputValidation.IsFilledIn(Isbn13))
						{
							
							if ((Isbn13.Length < 13 || InputValidation.IsNUll(Isbn13)) || !InputValidation.IsLong(Isbn13))
							{
								return $"The value isn't a correct {columnName}, the length must be 13 lang!";
							}
						}


						break;


					case nameof(Author):
						if (InputValidation.IsNUll(Author))
						{
							return $"The {columnName} can't be null!";
						}
						else if (Author.AuthorId == 0)
						{
							return $"The books {columnName} is required!";
						}
						break;

					case nameof(Genre):
						if (InputValidation.IsNUll(Genre))
						{
							return $"The {columnName} can't be null!";
						}
						else if (Genre.GenreId == 0)
						{
							return $"The books {columnName} is required!";
						}
						break;

					case nameof(Publisher):
						if (InputValidation.IsNUll(Publisher))
						{
							return $"The {columnName} can't be null!";
						}
						else if (Publisher.PublisherId == 0)
						{
							return $"The books {columnName} is required!";
						}
						break;

				}

				return string.Empty;
			}
		}


		public string Error
		{
			get;
		}

	} // end BookModel

} // end namespace

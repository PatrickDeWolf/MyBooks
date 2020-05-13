using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GeneralHelper.Lib;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public class AuthorModel : ModelBase, IAuthor, IDataErrorInfo
	{

		private int _authorId;
		public int AutherId
		{
			get
			{
				return _authorId;
			}
			set
			{
				if (_authorId == value) return;

				_authorId = value;
				RaisePropertyChanged();
			}
		}// end AutherId

		private string _firstname;
		public string Firstname
		{
			get
			{
				return _firstname;
			}
			set
			{
				if (_firstname == value) return;


				_firstname = value;
				RaisePropertyChanged();
			}
		}// end Firstname

		private string _lastname;
		public string Lastname
		{
			get
			{
				return _lastname;
			}
			set
			{
				if (_lastname == value) return;

				_lastname = value;
				RaisePropertyChanged();
			}
		}// end Lastname

		private string _pseudonym;
		public string Pseudonym
		{
			get
			{
				return _pseudonym;
			}
			set
			{
				if (_pseudonym == value) return;
				_pseudonym = value;
				RaisePropertyChanged();
			}
		}// end Pseudonym

		private DateTime _dateOfBirth;
		public DateTime DateOfBirth
		{
			get
			{
				return _dateOfBirth;
			}
			set
			{
				if (_dateOfBirth == value) return;


				_dateOfBirth = value;
				RaisePropertyChanged();
			}
		}// end DateOfBirth

		private DateTime? _diedOn;
		public DateTime? DiedOn
		{
			get
			{
				return _diedOn;
			}
			set
			{
				if (_diedOn == value) return;

				_diedOn = value;
				RaisePropertyChanged();
			}
		}// end DiedOn

		private string _nationality;
		public string Nationality
		{
			get
			{
				return _nationality;
			}
			set
			{
				if (_nationality == value) return;

				_nationality = value;
				RaisePropertyChanged();
			}
		}// end Nationality

		private string _photo;
		public string Photo
		{
			get
			{
				return _photo;
			}
			set
			{
				if (_photo == value) return;

				_photo = value;
				RaisePropertyChanged();
			}
		}// end Photo

		private List<IBook> _books;
		public List<IBook> Books
		{
			get
			{
				return _books ?? (_books = new List<IBook>());
			}
			set
			{
				if (_books == value) return;

				_books = value;
				RaisePropertyChanged();
			}
		}// end Books


		public string Error => "";

		public string this[string columnName]
		{
			get
			{
				switch (columnName)
				{
					case nameof(Firstname):
						if (!InputValidation.IsFilledIn(Firstname))
							return "The firstname is required!";
						break;

					case nameof(Lastname):
						if (!InputValidation.IsFilledIn(Lastname))
							return "The lastname is required!";
						break;

					case nameof(Pseudonym):
						break;

					case nameof(DateOfBirth):
						if (!InputValidation.IsDateOfBirth(DateOfBirth))
							return "The date of birth can't in the past!";
						break;

					case nameof(DiedOn):
						if (DiedOn.HasValue)
							if (!InputValidation.IsValidDate(DiedOn.Value, true))
								return "Died on after DOB!";
						break;

					default:
						break;
				}

				return string.Empty;
			}
		}


		 

		public override bool Equals(object obj)
		{
			// een controle op de voornaam, familienaam en geboortedatum
			// of op AuthorId
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

	} // end AuthorModel

} // end namespace

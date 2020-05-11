using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using GeneralHelper.Biblio;
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

				if (!InputValidation.IsFilledIn(value)) throw new ArgumentException("The firstname is required!");
		
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
				if (!InputValidation.IsFilledIn(value)) throw new ArgumentException("The lastname is required!");

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
				
				_pseudonym = value.Trim().Length == 0 ? $"{Firstname} {Lastname}" : value;

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

				if (!InputValidation.IsDateOfBirth(value)) throw new ArgumentException("The date of birth can't in the past!");

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
				if(value.HasValue)
					if (!InputValidation.IsValidDate(value.Value,true)) throw new ArgumentException("Died on after DOB!");

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
				return _books??(_books=new List<IBook>());
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
						break;
						
					default:
						break;
				}

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

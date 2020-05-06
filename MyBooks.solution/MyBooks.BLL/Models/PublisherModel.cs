using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public class PublisherModel : ModelBase,IPublisher
	{
		private int _publisherId;
		public int PublisherId
		{
			get
			{
				return _publisherId;
			}
			private set
			{
				if (_publisherId == value) return;

				_publisherId = value;
				RaisePropertyChanged(nameof(PublisherId));
			}
		}// end PublisherId


		private string _name;
		/// <summary>
		/// De naam van de uitgever
		/// </summary>
		public string Name
		{
			get { return _name; }
			set
			{
				if (_name == value) return;
				_name = value;
				RaisePropertyChanged();

			}
		}


		private string _website;
		/// <summary>
		/// De url van de website
		/// </summary>
		/// <example>http://www.starwars.com</example>
		/// <remarks>hier kan je opmerkingen vermelden</remarks>
		public string Website
		{
			get { return _website; }
			set
			{
				if (_website == value) return;

				_website = value;

				RaisePropertyChanged();

			}
		}

		private List<IBook> _books;
		/// <summary>
		/// De lijst van boeken van een uitgever
		/// </summary>
		public List<IBook> Books
		{
			get
			{
				if(_books==null)_books=new List<IBook>();
				return _books;
			}
			set
			{
				if (_books == value) return;
				_books = value;
				RaisePropertyChanged();
			}
		}

		// eventueel

		public PublisherModel()
		{
			
		}

		//public override string ToString()
		//{
		//	//return base.ToString();
		//	return Name;

		//}

		//public override bool Equals(object obj)
		//{
		//	return base.Equals(obj);
		//}

		//public override int GetHashCode()
		//{
		//	return base.GetHashCode();
		//}





	}// end PublisherModel

} //end namespace

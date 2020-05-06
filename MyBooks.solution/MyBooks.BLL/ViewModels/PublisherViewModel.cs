using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using MyBooks.BLL.Annotations;
using MyBooks.Contracts;


namespace MyBooks.BLL
{
	public class PublisherViewModel

	{

		// lokale variabelen voor DataService

		// properties voor binding met de view

		public  string PageTitle
		{
			get { return "Publisher"; }

		}


		private PublisherModel _publisher;

		public PublisherModel Publisher
		{
			get { return _publisher ?? (_publisher = new PublisherModel()); }

			set { _publisher = value; }
		}



		// MVVM Commands
		// public ICommand SaveCommand{ get{ //aanmaken van de ICommand implementatie}}


		// constructor
		public PublisherViewModel()
		{
			DesignData();

		}

		// public methods
		public void Save()
		{
			// Wegschrijven van de data
		}

		// private methods
		private void DesignData()
		{

			Publisher = new PublisherModel
			{
				Name = "Micrsoft Press", Website = "http://www.microsoft.be",
				Books=new List<IBook>()
				{
					new BookModel() { Title="OOP: Building Reusable Components With VB.NET",FrontCover = "../Assets/DesignDataImage1.jpg"},
					new BookModel(){Title = " MvvM in Xaramin.Forms", FrontCover = "../Assets/DesignDataImage2.png"}
				}
			};
		}


	} // end PublisherViewModel

} // end namespace

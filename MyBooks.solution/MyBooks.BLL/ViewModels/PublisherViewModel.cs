using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using GalaSoft.MvvmLight;
using MyBooks.BLL.Annotations;
using MyBooks.Contracts;


namespace MyBooks.BLL
{
	public class PublisherViewModel:ViewModelBase

	{

		// lokale variabelen voor DataService
		private IDataService _dataService;


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

		// List property met alle publishers
		private List<IPublisher> _publishers;
		public List<IPublisher> Publishers
		{
			get
			{
				return _publishers;
			}
			set
			{
				if (_publishers == value) return;

				_publishers = value;
				RaisePropertyChanged();
			}
		}// end PunlishersList


		// MVVM Commands
		// public ICommand SaveCommand{ get{ //aanmaken van de ICommand implementatie}}


		// constructor
		public PublisherViewModel(IDataService dataservice)
		{
			_dataService = dataservice;

			DesignData();

		}

		// public methods
		public void Save()
		{
			// Wegschrijven van de data
		}

		// private methods
		private async void DesignData()
		{

			Publishers = await _dataService.GetPublishers();

			Publisher = Publishers[1] as PublisherModel;

			//Publisher = new PublisherModel
			//{
			//	Name = "Micrsoft Press", Website = "http://www.microsoft.be",
			//	Books=new List<IBook>()
			//	{
			//		new BookModel() { Title="OOP: Building Reusable Components With VB.NET",FrontCover = "../Assets/DesignDataImage1.jpg"},
			//		new BookModel(){Title = " MvvM in Xaramin.Forms", FrontCover = "../Assets/DesignDataImage2.png"}
			//	}
			//};
		}


	} // end PublisherViewModel

} // end namespace

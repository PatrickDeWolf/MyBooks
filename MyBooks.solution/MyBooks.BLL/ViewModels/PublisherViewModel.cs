using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using GalaSoft.MvvmLight;

using MyBooks.Contracts;


namespace MyBooks.BLL
{
	public class PublisherViewModel : ViewModelBase

	{

		// lokale variabelen voor DataService
		private IDataService _dataService;


		// properties voor binding met de view

		public string PageTitle
		{
			get { return "Publisher"; }

		}


		private PublisherModel _publisher;

		public PublisherModel Publisher
		{
			get { return _publisher ?? (_publisher = new PublisherModel()); }

			set
			{
				if (_publisher == value) return;
				_publisher = value;
				RaisePropertyChanged();


			}
		}

		// List property met alle publishers
		private List<IPublisher> _publishers;
		public List<IPublisher> Publishers
		{
			get
			{
				// if _publishers == null -> create a new instance
				return _publishers ?? (_publishers = new List<IPublisher>());
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

	
		}


	} // end PublisherViewModel

} // end namespace

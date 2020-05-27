using System;
using System.Collections.Generic;
using System.Text;
using DannyVN.Library;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MyBooks.BLL.ViewModels;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public class ViewModelLocator
	{
		// voor Blend
		private static bool initialized;

		static ViewModelLocator()
		{
			//Fix to keep blend happy
			if (initialized)
			{
				return;
			}
			initialized = true;


			if (ViewModelBase.IsInDesignModeStatic)
			{
				// laden van designdata -> registratie van de DesignDataService
				if (!SimpleIoc.Default.IsRegistered<IDataService>())
				{
					SimpleIoc.Default.Register<IDataService, DesignDataService>();
				}
			}
			else
			{
				// laden van de run-time data --> registratie van de databron dataservice
				// --> SqlDataService -> gebruik van database
				// --> tekstbestanden: json, xml, csv, ....
				//	SimpleIoc.Default.Register<IDataService, RunTimeDataService>();
				//SimpleIoc.Default.Register<IDataService, DesignDataService>();

				if (!SimpleIoc.Default.IsRegistered<IDataService>())
				{
					SimpleIoc.Default.Register<IDataService, CsvDataService>();
				}

			}

			// registratie van de VIewModels
			// Register<T>
			SimpleIoc.Default.Register<MainViewModel>(); // Bind to MainView -> start page of the app
			SimpleIoc.Default.Register<BooksByAuthorViewModel>();

			SimpleIoc.Default.Register<PublisherViewModel>();
			SimpleIoc.Default.Register<AuthorViewModel>();
		//	SimpleIoc.Default.Register<BooksViewModel>();
			SimpleIoc.Default.Register<BookViewModel>(true);

			SetupNavigation();

		}

		// Creatie van de ViewModel Properties --> voor binding met de View
		public MainViewModel MainVm => SimpleIoc.Default.GetInstance<MainViewModel>();

		public BooksByAuthorViewModel HomeVm => SimpleIoc.Default.GetInstance<BooksByAuthorViewModel>();

		public PublisherViewModel PublisherVm
		{
			get { return SimpleIoc.Default.GetInstance<PublisherViewModel>(); }
		}

		public AuthorViewModel AuthorVm
		{
			get { return SimpleIoc.Default.GetInstance<AuthorViewModel>(); }
		}

	//	public BooksViewModel BooksVm
		//{
		//	get { return SimpleIoc.Default.GetInstance<BooksViewModel>(); }
		//}

		public BookViewModel BookVm => SimpleIoc.Default.GetInstance<BookViewModel>();

		public static void Cleanup()
		{
		}

		private static void SetupNavigation()
		{
			var navigationService = new NavigationService<NavigationPageEnum>();
			navigationService.ConfigurePages();
			SimpleIoc.Default.Register<INavigationService<NavigationPageEnum>>(() => navigationService);
		}

	}// end ViewModelLocator

}// end namespace

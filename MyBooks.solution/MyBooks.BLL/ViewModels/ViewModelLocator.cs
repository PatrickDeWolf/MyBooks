using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MyBooks.BLL.DataServices;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public class ViewModelLocator
	{

		static ViewModelLocator()
		{
			// declaratie van de Inversion of Control (IoC) container
			//ServiceLocator. 

			if (ViewModelBase.IsInDesignModeStatic)
			{
				// laden van designdata -> registratie van de DesignDataService
				SimpleIoc.Default.Register<IDataService,DesignDataService>();
			}
			else
			{
				// laden van de run-time data --> registratie van de databron dataservice
				// --> SqlDataService -> gebruik van database
				// --> tekstbestanden: json, xml, csv, ....
				SimpleIoc.Default.Register<IDataService,RunTimeDataService>();

			}

			// registratie van de VIewModels
			// Register<T>
			SimpleIoc.Default.Register<PublisherViewModel>();

		}

		// Creatie van de ViewModel Properties --> voor binding met de View
		public PublisherViewModel PublisherVm
		{
			get { return SimpleIoc.Default.GetInstance<PublisherViewModel>(); }
		}

	}// end ViewModelLocator

}// end namespace

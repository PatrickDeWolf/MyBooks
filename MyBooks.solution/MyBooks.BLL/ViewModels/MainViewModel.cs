using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DannyVN.Library;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using MyBooks.BLL.Messages;

namespace MyBooks.BLL
{
	public class MainViewModel:ViewModelBase
	{
		private INavigationService<NavigationPageEnum> _navigationService;

		public string ApplicationTitle => "My Super books app";

		private string _errorMessage;
		public string ErrorMessage
		{
			get
			{
				return _errorMessage;
			}
			set
			{
				if (_errorMessage == value)
					return;

				_errorMessage = value;
				RaisePropertyChanged();
			}
		}// end ErrorMessage


		public MainViewModel(INavigationService<NavigationPageEnum> navigationService)
		{

			_navigationService = navigationService;

			Messenger.Default.Register<ErrorMessage>
			(
				this, msg => ErrorMessage = msg.Message
			);
			//ErrorMessage = "Ok..";



		}

		// het aanmaken van de Icommand's welke de navigatie code bevatten
		// Bij staten van de applicatie (MainView) het surfen naar de betreffende startview met data 
		// LoadCommand -> binding aan het LoadEvent van een View/Page.....
		public ICommand LoadedCommand
		{
			get
			{
				return new RelayCommand(()=>_navigationService.NavigateTo(NavigationPageEnum.BooksByAuthorView));
			}
		}

		public ICommand PublisherCommand => new RelayCommand(() => _navigationService.NavigateTo(NavigationPageEnum.PublisherView));


	}//MainViewModel
}

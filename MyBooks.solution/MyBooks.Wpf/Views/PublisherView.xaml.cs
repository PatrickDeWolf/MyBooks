using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MyBooks.BLL;

namespace MyBooks.Wpf.Views
{
	/// <summary>
	/// Interaction logic for PublisherView.xaml
	/// </summary>
	public partial class PublisherView : Window
	{
		//private PublisherViewModel vm;

		public PublisherView()
		{
			InitializeComponent();

		//	vm = new PublisherViewModel();

			//// Koppelen van het ViewModel aan de View
			//this.DataContext = vm;
		//	this.DataContext=new PublisherViewModel();



		}


		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{
			//vm.Publisher.Website = "http://www.microsoft.com";
			//((PublisherViewModel)DataContext).Publisher.Website="http://www.microsoft.com";


		}

		private void CloseButton_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}

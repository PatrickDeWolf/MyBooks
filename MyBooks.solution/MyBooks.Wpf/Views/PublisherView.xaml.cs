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


		public PublisherView()
		{
			InitializeComponent();


		}


		private void SaveButton_OnClick(object sender, RoutedEventArgs e)
		{


		}

		private void CloseButton_OnClick(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}

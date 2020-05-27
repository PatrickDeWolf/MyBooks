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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyBooks.BLL.ViewModels;

namespace MyBooks.Wpf.Views
{
	/// <summary>
	/// Interaction logic for BooksByAuthorView.xaml
	/// </summary>
	public partial class BooksByAuthorView : Page
	{
		public BooksByAuthorView()
		{
			InitializeComponent();
		}

		private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			var msg = ((BooksByAuthorViewModel) DataContext).SelectedBook.Title;
			MessageBox.Show(msg, "Selected book",MessageBoxButton.OK,MessageBoxImage.Information);
		}
	}
}

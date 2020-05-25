using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using MyBooks.BLL;
using Path = System.IO.Path;

namespace MyBooks.Wpf.UserControls
{
	/// <summary>
	/// Interaction logic for BookUserControl.xaml
	/// </summary>
	public partial class BookUserControl : UserControl
	{
		public BookUserControl()
		{
			InitializeComponent();
		}

		private void FrontCoverButton_OnClick(object sender, RoutedEventArgs e)
		{
			var destination = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			var bookCover = "";
			if ((Button) sender == FrontCoverButton)
				bookCover = "FrontCover";
			else
				bookCover = "BackCover";

			OpenFileDialog openFileDialog = new OpenFileDialog();

			if (openFileDialog.ShowDialog() == true)
			{


				var newName = string.IsNullOrWhiteSpace(((BookViewModel)DataContext).Book.Isbn13)
							? $"{bookCover}-{((BookViewModel)DataContext).Book.Isbn}{Path.GetExtension(openFileDialog.FileName)}"
							: $"{bookCover}-{((BookViewModel)DataContext).Book.Isbn13}{Path.GetExtension(openFileDialog.FileName)}";

				File.Copy(openFileDialog.FileName, $@"{destination}\MyBooks\{newName}",true);
				((BookViewModel) DataContext).Book.FrontCover = newName;//openFileDialog.SafeFileName;
				//FrontCoverTextBox.Text = newName;//openFileDialog.SafeFileName;

			}

		}
	}
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Text;

using System.Globalization;

using System.IO;
using System.Windows.Data;

namespace MyBooks.Common
{
	public class PathToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
			{
				var cover = value.ToString();
				
				if (cover== "NoImage.png")
				{
					return  $"/MyBooks.Wpf;component/Assets/{cover}";
				}
				
				var path = $@"\MyBooks\{cover}";
			
			
				var systemPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

				var fullpath = $"{systemPath}{path}";

				return fullpath;

				//return Path.Combine(
				//	Environment.GetFolderPath(
				//		Environment.SpecialFolder.MyPictures), path);
			}
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	
	}
}

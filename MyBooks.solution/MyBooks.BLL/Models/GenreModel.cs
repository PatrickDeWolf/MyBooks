using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight;
using MyBooks.Contracts;

namespace MyBooks.BLL
{
	public class GenreModel:ViewModelBase, IGenre
	{
		private int _genreId;
		public int GenreId
		{
			get
			{
				return _genreId;
			}
			set
			{
				if (_genreId == value)
					return;

				_genreId = value;
				RaisePropertyChanged();
			}
		}// end GerneId

		public string Genre { get; set; }
		public string Pictogram { get; set; }
	
	} // end GerneModel

} // end namespace

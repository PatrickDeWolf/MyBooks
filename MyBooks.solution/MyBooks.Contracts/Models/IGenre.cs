using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Contracts
{
	/// <summary>
	/// 
	/// </summary>
	public interface IGenre
	{
		int GenreId { get; set; }
		string Genre { get; set; }

		string Pictogram { get; set; }

	} // end IGerne

}

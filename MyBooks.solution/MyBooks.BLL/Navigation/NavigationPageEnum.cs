using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.BLL
{
	public enum NavigationPageEnum
	{
		[Description("Startpage")]
		BooksByAuthorView,         //page with authors an all the books of an Author
		BookView,                  // page create a new or edit an existing one
		PublisherView,             // page create a new or edit an existing one
		GenreView                  // page create a new or edit an existing one

	}
}

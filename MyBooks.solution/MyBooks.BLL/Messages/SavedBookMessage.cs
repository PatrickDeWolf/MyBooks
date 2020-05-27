using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Contracts;

namespace MyBooks.BLL.Messages
{
	/// <summary>
	/// Het verzenden van een boek naar het overzicht van boeken
	/// </summary>
	public class SavedBookMessage
	{
		public IBook BookItem { get; set; }

	}
}

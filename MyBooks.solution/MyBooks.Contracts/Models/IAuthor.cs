using System;
using System.Collections.Generic;

namespace MyBooks.Contracts
{
	public interface IAuthor
	{

		string Firstname { get; set; }

		string Lastname { get; set; }

		string Pseudonym { get; set; }

		DateTime DateOfBirth { get; set; }

		DateTime? DiedOn { get; set; }

		string Nationality { get; set; }

		string Photo { get; set; }

		List<IBook> Books { get; set; }

	}// end IAuthor
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Contracts
{
	public interface IAuthor
	{
		int AuthorId { get; set; }
		string Firstname { get; set; }

		string Lastname { get; set; }

		string Pseudonym { get; set; }

		DateTime DateOfBirth { get; set; }

		DateTime? DiedOn { get; set; }

		string Nationality { get; set; }

		string Photo { get; set; }

		List<IBook> Books { get; set; }

		//List<IBook<ReadStatusEnum,ApprectiationEnum>> Books { get; set; }
	}
}

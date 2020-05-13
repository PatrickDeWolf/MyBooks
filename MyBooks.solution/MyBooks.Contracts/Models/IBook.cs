using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Contracts
{
	public interface IBook //<T, U> where T:Enum where U: Enum
	{
		Guid BookId { get; set; }
		string Title { get; set; }

		string FrontCover { get; set; }

		//ReadStatusEnum ReadStatus { get; set; }

		//ApprectiationEnum Apprectiation { set; get; }


	} // end Books


}


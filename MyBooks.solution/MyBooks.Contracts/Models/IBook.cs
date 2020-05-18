using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Contracts
{
	public interface IBook //<T, U> where T:Enum where U: Enum
	{
		Guid BookId{ get; set; }
		string Isbn { get; set; }
		string Isbn13{ get; set; }
		string Title { get; set; }
		string Language{get; set; }
		string FrontCover { get; set; }
		string BackCover { get; set; }
		bool Owned { get; set; }
		ReadStatusEnum ReadStatus { get; set; }
		ApprectiationEnum Apprectiation { set; get; }
		bool IsEbook { get; set; }
		string SerieName{get; set; }
		short SequenceNumber { get; set; }

		IPublisher Publisher { get; set; }
		IGenre  Genre { get; set; }
		IAuthor Author{ get; set; }

		int PublisherId {get; set; }
		int GenreId
		{
			get; set;
		}

		int AuthorId
		{
			get; set;
		}
	} // end Books


}


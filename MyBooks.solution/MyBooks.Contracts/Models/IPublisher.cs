using System.Collections.Generic;

namespace MyBooks.Contracts
{
	public interface IPublisher
	{
		string NAme { get; set; }

		string Website { get; set; }

		List<IBook> Books { get; set; }
		
	} // end IPublisher

} // end namespace
using System.Collections.Generic;

namespace MyBooks.Contracts
{
	public interface IPublisher
	{
		string Name { get; set; }

		string Website { get; set; }

	List<IBook> Books { get; set; }
		
	} // end IPublisher

} // end namespace
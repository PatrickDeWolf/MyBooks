using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBooks.Contracts
{
	public interface IPublisher
	{
		int PublisherId
		{
			get; set;
		}

		string Name { get; set; }

		string Website { get; set; }

		List<IBook> Books { get; set; }

	} // end IPublisher

}

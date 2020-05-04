using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace MyBooks.Contracts
{
	public interface IBook
	{

		string Title { get; set; }

	} // end Books

} // end namespace
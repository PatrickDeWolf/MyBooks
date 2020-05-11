using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace MyBooks.Contracts
{
	public interface IBook 
	{

		string Title { get; set; }

		string FrontCover { get; set; }

		//ReadStatusEnum ReadStatus { get; set; }

		//ApprectiationEnum Apprectiation { set; get; }


	} // end Books

} // end namespace
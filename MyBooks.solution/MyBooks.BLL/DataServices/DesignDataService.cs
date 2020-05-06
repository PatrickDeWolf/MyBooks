﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyBooks.Contracts;

namespace MyBooks.BLL.DataServices
{
	public class DesignDataService:IDataService
	{
		#region Publisher methods
		public void SavePublisher(IPublisher publisher)
		{
			throw new NotImplementedException();
		}

		public async Task<IPublisher> GetPublishers(IPublisher publisher)
		{
			throw new NotImplementedException();
		}

		public async Task<List<IPublisher>> GetPublishers()
		{
			return new List<IPublisher>()
			{
				new PublisherModel
				{
					Name = "Micrsoft Press",
					Website = "http://www.microsoft.be",
					Books = new List<IBook>()
					{
						new BookModel() { Title="OOP: Building Reusable Components With VB.NET",FrontCover = "../Assets/DesignDataImage1.jpg"},
						new BookModel(){Title = " MvvM in Xaramin.Forms", FrontCover = "../Assets/DesignDataImage2.png"}
					}
				},
				new PublisherModel
				{
					Name= "VanDuuren",
					Website ="http://www.vanduuren.nl",
					Books= new List<IBook>()
					{
						new BookModel{Title="ASP.NET CORE 3.1"}
					}
				}
			};

		} // end GetPublishers

		public void Delete(IPublisher publisher)
		{
			throw new NotImplementedException();
		}

		#endregion

	}// end DesignDataService

} // End namespace

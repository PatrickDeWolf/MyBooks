using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace MyBooks.Contracts
{
	/// <summary>
	/// De interface met de CRUD mehoden voor de verschillende dataservices
	/// </summary>
	/// <remarks>Alle methoden binnen de IDataService interface zijn al geschikt voor Asynchroon te werken.</remarks>
	public interface IDataService
	{
		/*
		 * Create -> aanmaken van een nieuw item		 -->	INSERT
		 *
		 * Read -> ophalen van een of meerdere items -->	SELECT
		 *
		 * Update -> wijzigen van een bestaand item	-->		UPDATE
		 *
		 * Delete -> schrappen van een bestaand item -->	DELETE (NOOIT rechtstreeks implementeren)
		 *
		 */

		#region Publisher methods
		void SavePublisher(IPublisher publisher);

		Task<List<IPublisher>> GetPublishers();

		Task<IPublisher> GetPublishers(IPublisher publisher);
		
		void Delete(IPublisher publisher); 
		#endregion


	} // end IDataService

}// end namespace
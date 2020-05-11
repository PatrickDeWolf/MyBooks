using System;

namespace GeneralHelper.Biblio
{
	/// <summary>
	/// Bibliotheek met algemene validatie methoden
	/// </summary>
	public static class InputValidation
	{
		/// <summary>
		/// Controle of een variable en of besturingselement een waarde heeft.
		/// </summary>
		/// <param name="value">De te controleren object</param>
		/// <returns>True wanneer is ingevuld, anders False.</returns>
		public static bool IsFilledIn(string value)
		{
			return (!IsNull(value) && value.Trim().Length> 0);
		}

		/// <summary>
		/// Controle of een object een NULL waarde bevat.
		/// </summary>
		/// <param name="value">Het te controleren object</param>
		/// <returns>True wanneer null waarde, anders False.</returns>
		public static bool IsNull(object value)
		{
			return value == null;

		}// end IsNull

		/// <summary>
		/// 
		/// </summary>
		/// <param name="waarde"></param>
		/// <returns></returns>
		public static bool IsInteger(string waarde)
		{
			/*
			 * 			int result;
			 *			return int.TryParse(waarde, out result);
			 */

			return int.TryParse(waarde, out _);

		} // end IsInteger

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <param name="minima"></param>
		/// <param name="maxima"></param>
		/// <returns></returns>
		/// <remarks>Inclusief minima en maxima</remarks>
		public static bool IsBetween(int value, int minima, int maxima)
		{

			if (value >= minima && value <= maxima)
				return true;
			else
				return false;
		}

		// if(IsBetween(postcode,1000,9999)) - 9300
		// byte, short, int, long, float, double, decimal, UInt, ULong, UShort,sByte
		// if(IsBetween(gebDatum,new DateTime(1999,01,01),new DateTime(2002,12,31))
		public static bool IsBetween<T>(T value, T minima, T maxima) where T:IComparable<T>
		{
			// -1	-> WAARDE kleiner is dan MINIMA
			// 0	-> WAARDE gelijk is aan	 MINIMA
			// 1	-> WAARDE groter is dan  MINIMA

			if ((value.CompareTo(minima) == 0 || value.CompareTo(minima) == 1) && (value.CompareTo(maxima) == 0 || value.CompareTo(maxima) == -1))
				return true;
			else
				return false;

		} // end IsBetween

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public static bool IsDateOfBirth(DateTime value)
		{
			return false;

		} // end IsDateOfBirth

		public static bool IsValidDate(DateTime date, bool inTePast = false)
		{
			// IsValidDate(new DateTime(2000,05,11)) == return false
			// IsValidDate(new DateTime(2000,05,11),true) == return true
			return false;
		}// end IsValidDate

		public static bool IsEmalAddress(string value)
		{
			return false;
		}

		public static bool IsUrl(string value)
		{
			return false;
		}



	} // end InputValidation
}

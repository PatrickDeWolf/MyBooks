using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GeneralHelper.Lib
{
	/// <summary>
	/// Een validatie bibliotheek.
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
			// string naam = "";
			// if(!naam.Equals(" ");
			return (!IsNUll(value) && value.Trim().Length>0);

		} // end IsFilledIn

		/// <summary>
		/// Controle of een object een NULL waarde bevat.
		/// </summary>
		/// <param name="value">Het te controleren object</param>
		/// <returns>True wanneer null waarde, anders False.</returns>
		public static bool IsNUll(object value)
		{
			return value==null;

		}// end IsNull

		public static bool IsByte(string value)
		{
			// Convert.ToByte(value); -> value="A" --> exception
			// byte.Parse(value); -> value="A" of value=300 --> exception
			byte result;

			return byte.TryParse(value,out result);

		}

		public static bool IsShort(string waarde)
		{
			short result;

			return short.TryParse(waarde, out result);
		} // end IsShort

		public static bool IsInteger(string waarde)
		{

			int result;

			return int.TryParse(waarde, out result);



		} // end IsInteger

		public static bool IsLong(string waarde)
		{
			long result;

			return long.TryParse(waarde, out result);
		}// end IsLong

		public static bool IsFloat(string waarde)
		{
			float result;
			return float.TryParse(waarde, out result);
		}

		public static bool IsDouble(string waarde)
		{
			double result;
			return double.TryParse(waarde, out result);
		} // end IsDouble

		// if(IsBetween(postcode,1000,9999))
		// byte, short, int, long, float, double, decimal, UInt, ULong, UShort,sByte
		// if(IsBetween(gebDatum,new DateTime(1999,01,01),new DateTime(2002,12,31))

		public static bool IsBetween<T>(T waarde, T minima, T maxima)
			where T : IComparable<T>
		{
			// -1	-> WAARDE kleiner is dan Maxima
			// 0	-> WAARDE gelijk is aan	 MINIMA of Maxima
			// 1	-> WAARDE groter is dan  MINIMA
			if ((waarde.CompareTo(minima) == 0 || waarde.CompareTo(minima) == 1) &&
			    (waarde.CompareTo(maxima) == 0 || waarde.CompareTo(maxima) == -1))
			{
				return true;
			}
			return false;
		}

		public static bool IsDateOfBirth(DateTime gebDate)
		{
			// Een geboortdatum kan nooit in de  toekomst liggen
			//if (gebDate.Date <= DateTime.Today.Date) return true;
			return (gebDate.Date <= DateTime.Today.Date);
			//return false;
		} // end IsDateOfBirth

		/// <summary>
		/// Check of a given date is in the futere of in the past
		/// </summary>
		/// <param name="date">the date to check</param>
		/// <param name="inTePast">Switch to check future or past</param>
		/// <returns>True when the date is in the future.</returns>
		/// <remarks>A date is valid when in the future and invalid when in the past. A other solution is write two methods one for a valid date in the future and the other for a valid date in the past</remarks>
		public static bool IsValidDate(DateTime date, bool inTePast = false)
		{
			// IIF( ) -> EXCEL, Word, Access, PowerPoint --> VBA
			return !inTePast ? date.Date >= DateTime.Today.Date : date.Date <= DateTime.Today.Date;

			//if (!inTePast)
			//	return date.Date >= DateTime.Today.Date;
			//else
			//{
			//	return date.Date <= DateTime.Today.Date;
			//}

		} // end IsValidDate

		public static bool IsEmailAddress(string email)
		{
			// check of email IsFilledIn
			if (InputValidation.IsFilledIn(email))
			{// @"(^{\d}{3}-[0-9]{7}-{\d}{3}$)"
				//mickey.mouse@disney.co.uk
				string regemail =
					@"(^[a-zA-Z0-9_\-].+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,15}$)";

				return Regex.IsMatch(email, regemail);
			}
			return true;
		}

		public static bool IsValidUrl(string url)
		{
			//var registrationCode = "C#RtW";
			//if(registrationCode == "JanMetDePet")
			//{
			//	//return leer the url
			//}
			
			throw new NotImplementedException("Alleen beschikaar in de betalende versie");
		}


		//000-0000000-00 "(^[0-9]{3}-[0-9]{7}-[0-9]{2}$)" of "(^\d{3}-\d{7}-\d{2}$)" 


	}// end InputValidation

} // end namespace

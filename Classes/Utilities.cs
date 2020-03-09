using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public static class Utilities
	{
		private const string illegalCharacterMessage = "Illegal character found";
        /// <summary> Get the hour from given time string </summary>
        /// <param name="aTime">given time</param>
        /// <returns>hours</returns>
		public static int GetHours(string aTime)
		{
			int hours;
			if (!int.TryParse(aTime.Split(':')[0], out hours))
				throw new ArgumentException(illegalCharacterMessage + " in hours!");
			return hours;
		}
        /// <summary> Get the minutes from given time string </summary>
        /// <param name="aTime">given time</param>
        /// <returns>minutes</returns>
		public static int GetMinutes(string aTime)
		{
			int minutes;
			if (!int.TryParse(aTime.Split(':')[1], out minutes))
				throw new ArgumentException(illegalCharacterMessage + " in minutes!");
			return minutes;
		}
        /// <summary> Get the seconds from given time string </summary>
        /// <param name="aTime">given time</param>
        /// <returns>seconds</returns>
		public static int GetSeconds(string aTime)
		{
			int seconds;
			if (!int.TryParse(aTime.Split(':')[2], out seconds))
				throw new ArgumentException(illegalCharacterMessage + " in seconds!");
			return seconds;
		}
        /// <summary> Validate that given time is in correct format </summary>
        /// <param name="aTime">given time</param>
        /// <returns>wheather time is in correct format or not</returns>
		public static bool IsValidTime(string aTime)
		{
			if (string.IsNullOrEmpty(aTime))
			{
				return false;
			}
			else if (aTime.Split(':').Length != 3)
			{
				return false;
			}
			else {
				int hours = GetHours(aTime); 
				int minutes = GetMinutes(aTime); 
				int seconds = GetSeconds(aTime); 
				if ( (hours >= 0 && hours <= 24) &&
					(minutes >= 0 && minutes < 60) &&
					(seconds >= 0 && seconds < 60) )
					return true;
				else 
					return false;
			}
		}
		
	}
}
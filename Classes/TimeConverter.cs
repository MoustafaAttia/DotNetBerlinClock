using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
	public class TimeConverter : ITimeConverter
	{
		private const string incorectMessage = "Incorrect time format! Format should be hh:mm:ss";
		private BerlinClockConverter solution;
		public string convertTime(string aTime)
		{
			if (!Utilities.IsValidTime(aTime))
			{
				throw new Exception(incorectMessage);
			}
			solution = new BerlinClockConverter(aTime);
			string result = solution.GetBerlinTimeFormat();

			return result;
		}
	}
}

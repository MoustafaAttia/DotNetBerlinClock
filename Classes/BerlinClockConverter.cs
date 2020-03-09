using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class BerlinClockConverter 
	{
        private string time;
        private int hours, minutes, seconds;
		private const string delimiter = "\r\n";
		public BerlinClockConverter(string aTime)
        {
            time = aTime;
            hours = Utilities.GetHours(time); 
			minutes = Utilities.GetMinutes(time); 
			seconds = Utilities.GetSeconds(time); 
        }
        private string GetSecondsLayer(int seconds)
		{
			return (seconds % 2) == 0 ? "Y" : "O";
		}
		private string GetTopLayerHour(int hour)
		{
			string result = "OOOO";
			hour = hour / 5;
			for(int i=0; i < hour; i++)
			{
				result = result.Remove(i,1).Insert(i,"R");
			}
			return result;
		}
		private string GetBottomLayerHour(int hour)
		{
			string result = "OOOO";
			hour = hour % 5;
			for(int i=0; i < hour; i++)
			{
				result = result.Remove(i,1).Insert(i,"R");
			}
			return result;
		}
		private string GetTopLayerMinute(int minute)
		{
			string result = "OOOOOOOOOOO";
			minute = minute / 5;
			for(int i=0; i < minute; i++)
			{
				result = result.Remove(i,1).Insert(i,"Y");
				if (i == 2 || i == 5 || i == 8)
				{
					result = result.Remove(i,1).Insert(i,"R");
				}
			}
			return result;
		}
		private string GetBottomLayerMinute(int minute)
		{
			string result = "OOOO";
			minute = minute % 5;
			for(int i=0; i < minute; i++)
			{
				result = result.Remove(i,1).Insert(i,"Y");
			}
			return result;
		}
		private string FormatResult(string[] berlinTimeFormat)
		{
			return string.Join(delimiter, Array.ConvertAll<object, string>(berlinTimeFormat.ToArray(), Convert.ToString));
		}

        /// <summary> Convert given time string to berlin clock formatted in one string </summary>
        /// <param></param>
        /// <returns> berlin time format seperated by new line each row </returns>
		public string GetBerlinTimeFormat()
		{
			string[] berlinTimeFormat = new string[5];
			string resultFormatted;
			berlinTimeFormat[0] = GetSecondsLayer(seconds);
			berlinTimeFormat[1] = GetTopLayerHour(hours);
			berlinTimeFormat[2] = GetBottomLayerHour(hours);
			berlinTimeFormat[3] = GetTopLayerMinute(minutes);
			berlinTimeFormat[4] = GetBottomLayerMinute(minutes);

			resultFormatted = FormatResult(berlinTimeFormat);

			return resultFormatted;
		}
	}
}
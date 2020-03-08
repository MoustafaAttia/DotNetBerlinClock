using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
	public class TimeConverter
	{
		private string ConvertSecondsLayer(int seconds)
		{
			return (seconds % 2) == 0 ? "Y" : "O";
		}
		private string ConvertTopLayerHour(int hour)
		{
			string result = "OOOO";
			hour = hour / 5;
			for(int i=0; i < hour; i++)
			{
				result = result.Remove(i,1).Insert(i,"R");
			}
			return result;
		}
		private string ConvertBottomLayerHour(int hour)
		{
			string result = "OOOO";
			hour = hour % 5;
			for(int i=0; i < hour; i++)
			{
				result = result.Remove(i,1).Insert(i,"R");
			}
			return result;
		}
		private string ConvertTopLayerMinute(int minute)
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
		private string ConvertBottomLayerMinute(int minute)
		{
			string result = "OOOO";
			minute = minute % 5;
			for(int i=0; i < minute; i++)
			{
				result = result.Remove(i,1).Insert(i,"Y");
				
			}
			return result;
		}
		private int GetHours(string aTime)
		{
			int hours = Convert.ToInt16(aTime.Split(':')[0]);
			return hours;
		}
		private int GetMinutes(string aTime)
		{
			int minutes = Convert.ToInt16(aTime.Split(':')[1]);
			return minutes;
		}
		private int GetMSeconds(string aTime)
		{
			int seconds = Convert.ToInt16(aTime.Split(':')[2]);
			return seconds;
		}
		private bool IsValidTime(string aTime)
		{
			bool result = true;
			if (string.IsNullOrEmpty(aTime))
			{
				result = false;
			}
			else if (aTime.Split(':').Length != 3)
			{
				result = false;
			}
			else {
				int hours = GetHours(aTime); 
				int minutes = GetMinutes(aTime); 
				int seconds = GetMSeconds(aTime); 
				if ( (hours >= 0 && hours <= 24) &&
					(minutes >= 0 && minutes < 60) &&
					(seconds >= 0 && seconds < 60) )
					result = true;
				else 
					result = false;
			}
			
			return result;
		}
		public string convertTime(string aTime)
		{
			string incorectMessage = "Incorrect time format!";
			
			if (!IsValidTime(aTime))
			{
				return incorectMessage;
			}

			string[] result = new string[5];
			int hours = GetHours(aTime); 
			int minutes = GetMinutes(aTime); 
			int seconds = GetMSeconds(aTime); 
			result[0] = ConvertSecondsLayer(seconds);
			result[1] = ConvertTopLayerHour(hours);
			result[2] = ConvertBottomLayerHour(hours);
			result[3] = ConvertTopLayerMinute(minutes);
			result[4] = ConvertBottomLayerMinute(minutes);

			return string.Join("\r\n", Array.ConvertAll<object, string>(result.ToArray(), Convert.ToString));

		}
	}
}

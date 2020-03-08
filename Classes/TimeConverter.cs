using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter
	{
		private string ConvertSeconds(string aTime)
		{
			int seconds = Convert.ToInt16(aTime.Split(':')[2]);
			return (seconds % 2) == 0 ? "Y" : "O";
		}
		private string ConvertHour(string aTime, int row)
		{
			if (row == 1)
			{
				return ConvertTopLayerHour(aTime);
			}
			else if (row == 2)
			{
				return ConvertBottomLayerHour(aTime);
			}
			else return string.Empty;
		}
		private string ConvertMinute(string aTime, int row)
		{
			if (row == 1)
			{
				return ConvertTopLayerMinute(aTime);
			}
			else if (row == 2)
			{
				return ConvertBottomLayerMinute(aTime);
			}
			else return string.Empty;
		}
		private string ConvertTopLayerHour(string aTime)
		{
			string result = "OOOO";
			int hour = Convert.ToInt16(aTime.Split(':')[0]);
			hour = hour / 5;
			for(int i=0; i < hour; i++)
			{
				result = result.Remove(i,1).Insert(i,"R");
			}
			return result;
		}
		private string ConvertBottomLayerHour(string aTime)
		{
			string result = "OOOO";
			int hour = Convert.ToInt16(aTime.Split(':')[0]);
			hour = hour % 5;
			for(int i=0; i < hour; i++)
			{
				result = result.Remove(i,1).Insert(i,"R");
			}
			return result;
		}
		private string ConvertTopLayerMinute(string aTime)
		{
			string result = "OOOOOOOOOOO";
			int minute = Convert.ToInt16(aTime.Split(':')[1]);
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
		private string ConvertBottomLayerMinute(string aTime)
		{
			string result = "OOOO";
			int minute = Convert.ToInt16(aTime.Split(':')[1]);
			minute = minute % 5;
			for(int i=0; i < minute; i++)
			{
				result = result.Remove(i,1).Insert(i,"Y");
				
			}
			return result;
		}
		public string convertTime(string aTime)
		{
			string incoorectMessage = "Incorrect time format!";
			if (string.IsNullOrEmpty(aTime))
			{
				return incoorectMessage;
			}
			if (aTime.Split(':').Length != 3)
			{
				return incoorectMessage;
			}

			string[] result = new string[5];
			result[0] = ConvertSeconds(aTime);
			result[1] = ConvertHour(aTime,1);
			result[2] = ConvertHour(aTime,2);
			result[3] = ConvertMinute(aTime,1);
			result[4] = ConvertMinute(aTime,2);

			return string.Join("\r\n", Array.ConvertAll<object, string>(result.ToArray(), Convert.ToString));

		}
	}
}

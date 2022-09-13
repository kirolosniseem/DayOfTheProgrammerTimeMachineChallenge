using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayOfTheProgrammerTimeMachine
{
    public class Program
    {
		static void Main(string[] args)
		{
			var input = string.Empty;
			do
			{
				Console.WriteLine("Please enter a year or 'end' to end");
				input = Console.ReadLine();
				int year = 0;
				int.TryParse(input, out year);
				if (year == 0)
				{
					Console.WriteLine("Invalid year");
					break;
				}
				string result = dayOfProgrammer(year);
				Console.WriteLine(result);
			}
			while (input != "end");
		}

		public static string dayOfProgrammer(int year)
		{
			Dictionary<int, int> monthsNumOfDays = new Dictionary<int, int>()
			{
				{1, 31},
				{2, 28},
				{3, 31},
				{4, 30},
				{5, 31},
				{6, 30},
				{7, 31},
				{8, 31},
				{9, 30},
				{10, 31},
				{11, 30},
				{12, 31}
			};

			if (year >= 1700 && year <= 1917)//Julian year
			{
				if (year % 4 == 0)
					monthsNumOfDays[2] = 29;
			}
			else if (year >= 1919 && year <= 2700)//Georgian year
			{
				if ((year % 400 == 0) || (year % 4 == 0 && year % 100 != 0))
					monthsNumOfDays[2] = 29;
			}
			else if (year == 1918)//transition year
			{
				monthsNumOfDays[2] = 15;
			}
			else
			{
				return "Year out of allowed range";
			}

			//locate the 256th day
			var currentNum = 0;
			var currentMonth = 0;
			var currentDayOfMonth = 0;

			while (currentNum != 256)
			{
				currentMonth++;
				currentDayOfMonth = 0;

				var currentMonthTotalDays = monthsNumOfDays[currentMonth];

				while (currentDayOfMonth < currentMonthTotalDays && currentNum != 256)
				{
					currentDayOfMonth++;
					currentNum++;
				}
			}

			return string.Format("{0}.{1}.{2}",
				currentDayOfMonth.ToString().PadLeft(2, '0'),
				currentMonth.ToString().PadLeft(2, '0'),
				year.ToString()
				);
		}

	}
}

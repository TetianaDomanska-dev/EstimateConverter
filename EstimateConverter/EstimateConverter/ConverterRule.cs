using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstimateConverter
{
	public static class ConverterRule
	{
		public static Dictionary<int, Tuple<double, double, double>> convertRule = new Dictionary<int, Tuple<double, double, double>>();
		public static void GenerateRule()
		{
			double optPercent = 0.8;  // 20% from most likely
			double pesPercent = 1.35; // 35% from most likely

			convertRule.Add(1, new Tuple<double, double, double>(0.3 * optPercent, 0.3 * pesPercent, 0.3));
			convertRule.Add(2, new Tuple<double, double, double>(0.8 * optPercent, 0.8 * pesPercent, 0.8));
			convertRule.Add(3, new Tuple<double, double, double>(1.2 * optPercent, 1.2 * pesPercent, 1.2));
			convertRule.Add(5, new Tuple<double, double, double>(2 * optPercent, 2 * pesPercent, 2));
			convertRule.Add(8, new Tuple<double, double, double>(3.5 * optPercent, 3.5 * pesPercent, 3.5));
			convertRule.Add(13, new Tuple<double, double, double>(5 * optPercent, 5 * pesPercent, 5));
			convertRule.Add(21, new Tuple<double, double, double>(7, 20, 15));
		}

		public static Tuple<double, double, double> GetManDayForSP(string SP)
		{
			var res = SP.Split(" ");
			int numOfSP = Convert.ToInt32(res[0]);
			return convertRule[numOfSP];
		}
	}
}

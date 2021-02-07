using System;
using LINQandXML.Helpers;

namespace LINQandXML
{
	public class Program
	{
		private static XMLHelper _xmlHelper;
		private static DataHelper _dataHelper;
		private static FormatHelper _formatHelper;

		internal static void Main()
		{
			_xmlHelper = new XMLHelper();
			_dataHelper = new DataHelper();
			_formatHelper = new FormatHelper();

			int year;
			double minTotal;

			while (true)
			{
				Console.Write("Podaj rok: ");
				if (!int.TryParse(Console.ReadLine(), out year) || year <= 0)
					Console.WriteLine("Niepoprawna wartość");
				else break;
			}

			while (true)
			{
				Console.Write("Podaj wartość minimalną zamówienia: ");
				var min = Console.ReadLine()?.Replace(".", ",");
				if (!double.TryParse(min, out minTotal) || minTotal <= 0)
					Console.WriteLine("Niepoprawna wartość");
				else break;
			}

			var customers = _dataHelper.GetCustomers();

			Console.WriteLine(_xmlHelper.SerializeCustomersToXML(customers));
			Console.Write("\n\n" + _formatHelper.FormatListOfCustomersToStandardOutput(customers, year, minTotal));

			Console.ReadKey();
		}
	}
}

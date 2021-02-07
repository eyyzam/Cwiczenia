using System;
using LINQandXML.Helpers;

namespace LINQandXML
{
	public class Program
	{
		private static XMLHelper _xmlHelper;
		private static DataHelper _dataHelper;

		internal static void Main()
		{
			_xmlHelper = new XMLHelper();
			_dataHelper = new DataHelper();

			var customers = _dataHelper.GetCustomers();

			Console.WriteLine(_xmlHelper.SerializeCustomersToXML(customers));
			Console.ReadKey();
		}
	}
}

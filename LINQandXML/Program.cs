using System;
using LINQandXML.Helpers;

namespace LINQandXML
{
	public class Program
	{
		private readonly XMLHelper _xmlHelper;

		public Program(XMLHelper xmlHelper)
		{
			_xmlHelper = xmlHelper;
		}

		internal static void Main()
		{
			Console.WriteLine("Hello World!");
		}
	}
}

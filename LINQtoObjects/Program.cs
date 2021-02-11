using System;
using System.Linq;

namespace LINQtoObjects
{
	public class Program
	{
		internal static void Main(string[] args)
		{
			string input;

			while (true)
			{
				Console.Write("Podaj sekwencję cięć materiału: ");
				input = Console.ReadLine();

				if (string.IsNullOrEmpty(input))
					Console.WriteLine("Niepoprawna wartość");
				else break;
			}

			var result = input.Split('-')
							  .Select((row, i) => (row.Contains(';') ? row : i == 0 ? (row == "0:00:00" ? "" : $"0:00:00;{row}") : (row == "2:00:00" ? "" : $"{row};2:00:00"))
							  .Replace(";", "-"))
							  .Where(row => row.Any())
							  .Aggregate((left, right) => $"{left};{right}");

			Console.WriteLine(string.IsNullOrEmpty(result) ? "\nempty" : $"\n{result}");
			Console.ReadKey();
		}
	}
}

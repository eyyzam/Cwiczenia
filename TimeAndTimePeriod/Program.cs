using System;

// ReSharper disable once CheckNamespace
public class Program
{
	internal static void Main(string[] args)
	{
		var time = new Time(12, 30, 50, 911);
		Console.WriteLine("Time Struct -> 12h 30m 50s 911ms");
		Console.WriteLine($"Hours: {time.Hours}");
		Console.WriteLine($"Minutes: {time.Minutes}");
		Console.WriteLine($"Seconds: {time.Seconds}");
		Console.WriteLine($"Miliseconds: {time.Miliseconds}");

		var timeString = new Time("9:07:59:123");
		Console.WriteLine("\nTime Struct (Constructed by string param) -> \"9:07:59:123\"");
		Console.WriteLine($"Hours: {timeString.Hours}");
		Console.WriteLine($"Minutes: {timeString.Minutes}");
		Console.WriteLine($"Seconds: {timeString.Seconds}");
		Console.WriteLine($"Miliseconds: {timeString.Miliseconds}");
		
		Console.WriteLine("\nTime Struct -> ToString()");
		Console.WriteLine($"Variable: time -> {time.ToString()}");
		Console.WriteLine($"Variable: timeString -> {timeString.ToString()}");

		Console.ReadKey();
	}
}
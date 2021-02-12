using System;

// ReSharper disable once CheckNamespace
public struct Time
{
	private uint _miliseconds;
	private byte _seconds, _minutes, _hours;

	public uint Miliseconds
	{
		get => _miliseconds;
		private set => _miliseconds = value % 1000;
	}

	public byte Seconds
	{
		get => _seconds;
		private set => _seconds = Convert.ToByte(value % 60);
	}

	public byte Minutes
	{
		get => _minutes;
		private set => _minutes = Convert.ToByte(value % 60);
	}

	public byte Hours
	{
		get => _hours;
		private set => _hours = Convert.ToByte(value % 24);
	}

	public Time(byte hours, byte minutes, byte seconds, uint miliseconds) : this()
	{
		Seconds = seconds;
		Minutes = minutes;
		Seconds = seconds;
		Miliseconds = miliseconds;
	}

	public Time(byte hours, byte minutes, byte seconds) : this(hours, minutes, seconds, 0) { }

	public Time(byte hours, byte minutes) : this(hours, minutes, 0, 0) { }

	public Time(byte hours) : this(hours, 0, 0, 0) { }

	public Time(string time) : this() { }
}


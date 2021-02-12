// ReSharper disable once CheckNamespace

using System;

public struct Time
{
	private int _miliseconds;
	private byte _seconds, _minutes, _hours;

	public int Miliseconds
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
}


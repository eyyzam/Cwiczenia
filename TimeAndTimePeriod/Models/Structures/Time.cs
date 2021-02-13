using System;
using System.Linq;

// ReSharper disable once CheckNamespace
public struct Time : IEquatable<Time>, IComparable<Time>
{
	private const long _ticksPerMilisecond = 10000;
	private const long _ticksPerSecond = _ticksPerMilisecond * 1000;
	private const long _ticksPerMinute = _ticksPerSecond * 60;
	private const long _ticksPerHour = _ticksPerMinute * 60;
	private const long _ticksPerDay = _ticksPerHour * 24;

	private const int _secondsInHour = 3600;
	private const int _secondsInMinute = 60;
	private const int _milisecondsInSecond = 1000;

	private long _ticks;
	private uint _miliseconds;
	private byte _seconds, _minutes, _hours;

	public long Ticks
	{
		get => _ticks;
		private set => _ticks = value > _ticksPerDay ? throw new ArgumentOutOfRangeException() : value;
	} 

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
		Miliseconds = miliseconds;
		Seconds = seconds;
		Minutes = minutes;
		Hours = hours;

		CalculateTicks();
	}

	public Time(byte hours, byte minutes, byte seconds) : this(hours, minutes, seconds, 0) { }

	public Time(byte hours, byte minutes) : this(hours, minutes, 0, 0) { }

	public Time(byte hours) : this(hours, 0, 0, 0) { }

	public Time(string time) : this()
	{
		if (time is null || time.Length == 0)
			throw new ArgumentException();

		var separatedTimeProperties = time.Split(':').Select(prop => Convert.ToUInt16(prop).ToString("D2")).ToList();

		Hours = byte.TryParse(separatedTimeProperties[0], out var _h) ? _h : (byte) 0;
		Minutes = byte.TryParse(separatedTimeProperties[1], out var _m) ? _m : (byte) 0;
		Seconds = byte.TryParse(separatedTimeProperties[2], out var _s) ? _s : (byte) 0;

		if (separatedTimeProperties.Count != 4)
		{
			CalculateTicks(_h, _m, _s, 0);
			return;
		}

		Miliseconds = uint.TryParse(separatedTimeProperties[3], out var _ms) ? _ms : 0;
		CalculateTicks(_h, _m, _s, (int) _ms);
	}

	private void CalculateTicks()
	{
		var resultMiliseconds = (Hours * _secondsInHour + Minutes * _secondsInMinute + Seconds) * _milisecondsInSecond + Miliseconds;
		Ticks = resultMiliseconds * _ticksPerMilisecond;
	}

	private void CalculateTicks(byte hours, byte minutes, byte seconds, int miliseconds)
	{
		long resultMiliseconds = (hours * _secondsInHour + minutes * _secondsInMinute + seconds) * _milisecondsInSecond + miliseconds;
		_ticks = resultMiliseconds * _ticksPerMilisecond;
	}

	public override string ToString()
	{
		return $"{Hours:00}:{Minutes:00}:{Seconds:00}:{Miliseconds:000}";
	}

	public bool Equals(Time otherTimeInstance) => Ticks == otherTimeInstance.Ticks;

	public override bool Equals(object obj) => obj is Time otherTimeInstance && Equals(otherTimeInstance);

	public override int GetHashCode() => (Hours, Minutes, Seconds, Miliseconds).GetHashCode();

	public int CompareTo(Time otherTimeInstance) => Ticks > otherTimeInstance.Ticks ? 1 : Ticks < otherTimeInstance.Ticks ? -1 : 0;

	public static bool operator == (Time t1, Time t2) => t1.Ticks == t2.Ticks;
	public static bool operator != (Time t1, Time t2) => t1.Ticks != t2.Ticks;
	public static bool operator <  (Time t1, Time t2) => t1.Ticks < t2.Ticks;
	public static bool operator <= (Time t1, Time t2) => t1.Ticks <= t2.Ticks;
	public static bool operator >  (Time t1, Time t2) => t1.Ticks > t2.Ticks;
	public static bool operator >= (Time t1, Time t2) => t1.Ticks >= t2.Ticks;
}


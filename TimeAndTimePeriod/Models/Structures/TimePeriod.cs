using System;
using System.Linq;

// ReSharper disable once CheckNamespace
public readonly struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
{
	private const long _ticksPerMilisecond = 10000;
	private const long _ticksPerSecond = _ticksPerMilisecond * 1000;
	private const long _ticksPerMinute = _ticksPerSecond * 60;
	private const long _ticksPerHour = _ticksPerMinute * 60;

	private const int _secondsInHour = 3600;
	private const int _secondsInMinute = 60;
	private const int _milisecondsInSecond = 1000;

	private long Miliseconds => (Ticks / _ticksPerMilisecond) % 1000;
	private long Seconds => (Ticks / _ticksPerSecond) % 60;
	private long Minutes => (Ticks / _ticksPerMinute) % 60;
	private long Hours => (Ticks / _ticksPerHour);

	public long Ticks { get; }
	public long MilisecondsTotal { get; }
	public long SecondsTotal { get; }

	public TimePeriod(uint hours, uint minutes, uint seconds, uint miliseconds) : this()
	{
		SecondsTotal = hours * _secondsInHour + (minutes % 60) * _secondsInMinute + (seconds % 60);
		MilisecondsTotal = SecondsTotal * _milisecondsInSecond + (miliseconds % 1000);
		Ticks = MilisecondsTotal * _ticksPerMilisecond;
	}

	public TimePeriod(uint hours, uint minutes) : this()
	{
		SecondsTotal = hours * _secondsInHour + (minutes % 60) * _secondsInMinute;
		MilisecondsTotal = SecondsTotal * _milisecondsInSecond;
		Ticks = MilisecondsTotal * _ticksPerMilisecond;
	}

	public TimePeriod(ulong seconds) : this()
	{
		SecondsTotal = (long) seconds;
		MilisecondsTotal = SecondsTotal * _milisecondsInSecond;
		Ticks = MilisecondsTotal * _ticksPerMilisecond;
	}

	public TimePeriod(long miliseconds) : this()
	{
		SecondsTotal = miliseconds / _milisecondsInSecond;
		MilisecondsTotal = SecondsTotal * _milisecondsInSecond;
		Ticks = MilisecondsTotal * _ticksPerMilisecond;
	}

	public TimePeriod(Time t1, Time t2) : this()
	{
		var comparision = t1.CompareTo(t2);
		var timeTicksSubtracted = comparision == 1 ? t1.Ticks - t2.Ticks : t2.Ticks - t1.Ticks;

		SecondsTotal = timeTicksSubtracted / _ticksPerSecond;
		MilisecondsTotal = Seconds * _milisecondsInSecond;
		Ticks = Miliseconds * _ticksPerMilisecond;
	}

	public TimePeriod(string time) : this()
	{
		if (time is null || time.Length == 0)
			throw new ArgumentException();

		var separatedTimeProperties = time.Split(':').Select(prop => Convert.ToUInt64(prop)).Skip(1).Select(prop => prop.ToString("D2")).ToList();

		if (separatedTimeProperties.Count != 3 && separatedTimeProperties.Count != 4)
			throw new ArgumentException();

		_ = ulong.TryParse(separatedTimeProperties[0], out var _h) ? _h : 0;
		_ = ulong.TryParse(separatedTimeProperties[1], out var _m) ? _m : 0;
		_ = ulong.TryParse(separatedTimeProperties[2], out var _s) ? _s : 0;

		if (separatedTimeProperties.Count != 4)
		{
			MilisecondsTotal = (long) CalculateMiliseconds(_h, _m % 60, _s % 60, 0);
			SecondsTotal = Miliseconds / _milisecondsInSecond;
			return;
		}

		_ = ulong.TryParse(separatedTimeProperties[0], out var _ms) ? _ms : 0;
		MilisecondsTotal = (long) CalculateMiliseconds(_h, _m % 60, _s % 60, _ms % 1000);
		SecondsTotal = Miliseconds / _milisecondsInSecond;
	}

	private static ulong CalculateMiliseconds(ulong hours, ulong minutes, ulong seconds, ulong miliseconds)
	{
		var ms = (hours * _secondsInHour + minutes * _secondsInMinute + seconds) * _milisecondsInSecond + miliseconds;

		return ms == 0 ? throw new ArgumentOutOfRangeException() : ms;
	}

	public override string ToString()
	{
		var miliseconds = Miliseconds == 0 ? "" : $@":{Miliseconds:000}";
		return $"{Hours:0}:{Minutes:00}:{Seconds:00}{miliseconds}";
	}

	public bool Equals(TimePeriod otherTimePeriodInstance) => Ticks == otherTimePeriodInstance.Ticks;

	public override bool Equals(object obj) => obj is TimePeriod otherTimePeriodInstance && Equals(otherTimePeriodInstance);

	public override int GetHashCode() => (Hours, Minutes, Seconds, Miliseconds).GetHashCode();

	public int CompareTo(TimePeriod otherTimePeriodInstance) => Ticks > otherTimePeriodInstance.Ticks ? 1 : Ticks < otherTimePeriodInstance.Ticks ? -1 : 0;

	public static bool operator == (TimePeriod a, TimePeriod b) => a.Ticks == b.Ticks;
	public static bool operator != (TimePeriod a, TimePeriod b) => a.Ticks != b.Ticks;
	public static bool operator <  (TimePeriod a, TimePeriod b) => a.Ticks <  b.Ticks;
	public static bool operator <= (TimePeriod a, TimePeriod b) => a.Ticks <= b.Ticks;
	public static bool operator >  (TimePeriod a, TimePeriod b) => a.Ticks >  b.Ticks;
	public static bool operator >= (TimePeriod a, TimePeriod b) => a.Ticks >= b.Ticks;

	public TimePeriod Plus(TimePeriod otherTimePeriodInstance) => new TimePeriod(MilisecondsTotal + otherTimePeriodInstance.MilisecondsTotal);
	public static TimePeriod Plus(TimePeriod t1, TimePeriod t2) => new TimePeriod(t1.MilisecondsTotal + t2.MilisecondsTotal);

	public TimePeriod Minus(TimePeriod otherTimePeriodInstance) => new TimePeriod(MilisecondsTotal - otherTimePeriodInstance.MilisecondsTotal);
	public static TimePeriod Minus(TimePeriod t1, TimePeriod t2) => new TimePeriod(t1.MilisecondsTotal - t2.MilisecondsTotal);

	public static TimePeriod operator + (TimePeriod t1, TimePeriod t2) => t1.Plus(t2);
	public static TimePeriod operator - (TimePeriod t1, TimePeriod t2) => t1.Minus(t2);
}


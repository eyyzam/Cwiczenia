using System;
using System.Linq;

// ReSharper disable once CheckNamespace
public struct TimePeriod
{
	private const long _ticksPerMilisecond = 10000;
	private const long _ticksPerSecond = _ticksPerMilisecond * 1000;
	private const long _ticksPerMinute = _ticksPerSecond * 60;
	private const long _ticksPerHour = _ticksPerMinute * 60;

	private const int _secondsInHour = 3600;
	private const int _secondsInMinute = 60;
	private const int _milisecondsInSecond = 1000;

	public long Ticks { get; }
	public long Miliseconds { get; }
	public long Seconds { get; }

	public TimePeriod(uint hours, uint minutes, uint seconds, uint miliseconds) : this()
	{
		Seconds = hours * _secondsInHour + (minutes % 60) * _secondsInMinute + (seconds % 60);
		Miliseconds = Seconds * _milisecondsInSecond + (miliseconds % 1000);
		Ticks = Miliseconds * _ticksPerMilisecond;
	}

	public TimePeriod(uint hours, uint minutes) : this()
	{
		Seconds = hours * _secondsInHour + (minutes % 60) * _secondsInMinute;
		Miliseconds = Seconds * _milisecondsInSecond;
		Ticks = Miliseconds * _ticksPerMilisecond;
	}

	public TimePeriod(ulong seconds) : this()
	{
		Seconds = (long) seconds;
		Miliseconds = Seconds * _milisecondsInSecond;
		Ticks = Miliseconds * _ticksPerMilisecond;
	}

	public TimePeriod(Time t1, Time t2) : this()
	{
		var comparision = t1.CompareTo(t2);
		var timeTicksSubtracted = comparision == 1 ? t1.Ticks - t2.Ticks : t2.Ticks - t1.Ticks;

		Seconds = timeTicksSubtracted / _ticksPerSecond;
		Miliseconds = Seconds * _milisecondsInSecond;
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
			Miliseconds = (long) CalculateMiliseconds(_h, _m % 60, _s % 60, 0);
			Seconds = Miliseconds / _milisecondsInSecond;
			return;
		}

		_ = ulong.TryParse(separatedTimeProperties[0], out var _ms) ? _ms : 0;
		Miliseconds = (long) CalculateMiliseconds(_h, _m % 60, _s % 60, _ms % 1000);
		Seconds = Miliseconds / _milisecondsInSecond;
	}

	private static ulong CalculateMiliseconds(ulong hours, ulong minutes, ulong seconds, ulong miliseconds)
	{
		var ms = (hours * _secondsInHour + minutes * _secondsInMinute + seconds) * _milisecondsInSecond + miliseconds;

		if (ms == 0) throw new ArgumentOutOfRangeException();
		return ms;
	}
}


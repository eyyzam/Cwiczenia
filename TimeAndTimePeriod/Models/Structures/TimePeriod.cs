using System;

// ReSharper disable once CheckNamespace
public struct TimePeriod
{
	private const long _ticksPerMilisecond = 10000;
	private const long _ticksPerSecond = _ticksPerMilisecond * 1000;
	private const long _ticksPerMinute = _ticksPerSecond * 60;
	private const long _ticksPerHour = _ticksPerMinute * 60;

	private const int secondsInHour = 3600;
	private const int secondsInMinute = 60;
	private const int milisecondsInSecond = 1000;

	public long Ticks { get; }
	public long Miliseconds { get; }
	public long Seconds { get; }

	public TimePeriod(uint hours, uint minutes, ulong seconds, ulong miliseconds) : this()
	{
		Seconds = hours * secondsInHour + minutes * secondsInMinute + Seconds;
		Miliseconds = Seconds * milisecondsInSecond + (long) miliseconds;
		Ticks = (long) miliseconds * _ticksPerMilisecond;
	}

	public TimePeriod(uint hours, uint minutes) : this()
	{

	}

	public TimePeriod(long seconds) : this()
	{

	}

	public TimePeriod(Time t1, Time t2) : this()
	{

	}

	public TimePeriod(string time) : this()
	{

	}
}


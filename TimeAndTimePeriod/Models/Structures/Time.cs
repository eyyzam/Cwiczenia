// ReSharper disable once CheckNamespace
public struct Time
{
	private int _miliseconds;
	private byte _seconds, _minutes, _hours;

	public int Miliseconds => _miliseconds;

	public byte Seconds => _seconds;

	public byte Minutes => _minutes;

	public byte Hours => _hours;
}


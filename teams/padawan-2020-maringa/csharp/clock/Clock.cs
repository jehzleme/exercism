using System;

public partial class Clock
{
    internal int Hours { get; }
    internal int Minutes { get; }
    public Clock(int hours, int minutes)
    {
        Hours = (hours + (minutes / 60)) % 24;        Minutes = minutes % 60;        if (Minutes < 0)        {            Hours--;            Minutes = 60 + Minutes;        }        if (Hours < 0)        {            Hours = 24 + Hours;        }

    }

    public Clock Add(int minutesToAdd)
    {
        throw new NotImplementedException("You need to implement this function.");
    }

    public Clock Subtract(int minutesToSubtract)
    {
        throw new NotImplementedException("You need to implement this function.");
    }
}

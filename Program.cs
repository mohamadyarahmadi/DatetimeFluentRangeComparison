DateTime minDate = new DateTime(2024, 1, 1);
DateTime flightDate = new DateTime(2024, 1, 15);
DateTime maxDate = new DateTime(2024, 1, 31);

if (minDate <= (RangeComparer)flightDate <= maxDate)
{
    // Your logic here
    Console.WriteLine("Flight date is within range!");
}

public class RangeComparer
{
    private DateTime _currentDate;
    private bool _isInRange;

    public RangeComparer(DateTime date)
    {
        _currentDate = date;
        _isInRange = true;
    }

    public static RangeComparer operator <=(DateTime minDate, RangeComparer rangeComparer)
    {
        rangeComparer._isInRange = rangeComparer._isInRange && minDate <= rangeComparer._currentDate;
        return rangeComparer;
    }

    public static RangeComparer operator >=(DateTime minDate, RangeComparer rangeComparer)
    {
        rangeComparer._isInRange = rangeComparer._isInRange && minDate >= rangeComparer._currentDate;
        return rangeComparer;
    }

    public static bool operator <=(RangeComparer rangeComparer, DateTime maxDate)
    {
        return rangeComparer._isInRange && rangeComparer._currentDate <= maxDate;
    }

    public static bool operator >=(RangeComparer rangeComparer, DateTime maxDate)
    {
        return rangeComparer._isInRange && rangeComparer._currentDate >= maxDate;
    }

    public static implicit operator RangeComparer(DateTime dateTime)
    {
        return new RangeComparer(dateTime);
    }
}

using System;

public class Clock : IEquatable<Clock>
{
    private readonly int minutes;

    public Clock(int hours, int minutes)
    {
        // переводим всё в минуты
        int total = hours * 60 + minutes;

        // нормализация по модулю количества минут в сутках
        int day = 24 * 60;
        total = ((total % day) + day) % day;

        this.minutes = total;
    }

    public Clock Add(int minutesToAdd)
        => new Clock(0, this.minutes + minutesToAdd);

    public Clock Subtract(int minutesToSubtract)
        => new Clock(0, this.minutes - minutesToSubtract);

    public override string ToString()
    {
        int h = minutes / 60;
        int m = minutes % 60;
        return $"{h:00}:{m:00}";
    }

    // === Реализация равенства ===

    public override bool Equals(object? obj)
        => Equals(obj as Clock);

    public bool Equals(Clock? other)
        => other is not null && this.minutes == other.minutes;

    public override int GetHashCode()
        => minutes.GetHashCode();

    public static bool operator ==(Clock left, Clock right)
        => Equals(left, right);

    public static bool operator !=(Clock left, Clock right)
        => !Equals(left, right);
}

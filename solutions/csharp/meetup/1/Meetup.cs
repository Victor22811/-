using System;
using System.Collections.Generic;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private int _year;
    private int _month;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        int daysInMonth = DateTime.DaysInMonth(_year, _month);

        List<DateTime> matchingDays = new List<DateTime>();

        // Собираем все даты нужного дня недели
        for (int day = 1; day <= daysInMonth; day++)
        {
            DateTime date = new DateTime(_year, _month, day);
            if (date.DayOfWeek == dayOfWeek)
                matchingDays.Add(date);
        }

        // Выбираем по расписанию
        switch (schedule)
        {
            case Schedule.First:
                return matchingDays[0];
            case Schedule.Second:
                return matchingDays.Count > 1 ? matchingDays[1] : throw new InvalidOperationException();
            case Schedule.Third:
                return matchingDays.Count > 2 ? matchingDays[2] : throw new InvalidOperationException();
            case Schedule.Fourth:
                return matchingDays.Count > 3 ? matchingDays[3] : throw new InvalidOperationException();
            case Schedule.Last:
                return matchingDays[matchingDays.Count - 1];
            case Schedule.Teenth:
                foreach (var date in matchingDays)
                {
                    if (date.Day >= 13 && date.Day <= 19)
                        return date;
                }
                break;
        }

        throw new InvalidOperationException("No valid date found for given schedule");
    }
}

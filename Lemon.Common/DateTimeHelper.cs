namespace Lemon.Common
{
    using System;

    public static class DateTimeHelper
    {
        public static string GetOutTime(DateTime date)
        {
            var utcNow = DateTime.UtcNow;
            var diff = utcNow - date;
            if (diff.TotalMinutes < 1)
            {
                return "только что";
            }

            if (diff.TotalHours < 1)
            {
                var totalMinutes = (int)diff.TotalMinutes;
                if (totalMinutes == 1)
                {
                    return string.Format("минуту назад");
                }
                if (totalMinutes <= 20  && totalMinutes >= 5)
                {
                    return string.Format("{0} минут назад", totalMinutes);
                }
                if (totalMinutes % 10 == 1)
                {
                    return string.Format("{0} минуту назад", totalMinutes);
                }
                if (totalMinutes % 10 <= 4 && totalMinutes % 10 != 0)
                {
                    return string.Format("{0} минуты назад", totalMinutes);
                }

                return string.Format("{0} минут назад", totalMinutes);
            }

            if (diff.TotalDays < 1)
            {
                var totalHours = (int)diff.TotalHours;
                if (totalHours == 1)
                {
                    return string.Format("час назад");
                }
                if (totalHours <= 20 && totalHours >= 5)
                {
                    return string.Format("{0} часов назад", totalHours);
                }
                if (totalHours % 10 == 1)
                {
                    return string.Format("{0} час назад", totalHours);
                }
                if (totalHours % 10 <= 4 && totalHours % 10 != 0)
                {
                    return string.Format("{0} часа назад", totalHours);
                }

                return string.Format("{0} часов назад", totalHours);
            }

            var totalDays = (int)diff.TotalDays;
            if (totalDays == 1)
            {
                return string.Format("день назад");
            }
            if (totalDays % 10 <= 4)
            {
                return string.Format("{0} дня назад", totalDays);
            }

            return string.Format("{0} дней назад", totalDays);
        }
    }
}
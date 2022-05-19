 using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace UtilitySpace
{
    public static class DataTimeEx
    {
        public static DateTime ToShamsi(this DateTime Dt)
        {
            PersianCalendar pDate = new PersianCalendar();

            int Day = pDate.GetDayOfMonth(Dt);
            int Month = pDate.GetMonth(Dt);
            int Year = pDate.GetYear(Dt);

            int Hour = pDate.GetHour(Dt);
            int Minute = pDate.GetMinute(Dt);
            int Second = pDate.GetSecond(Dt);

            return new DateTime(Year, Month, Day, Hour, Minute, Second);

        }
    }

}

using System;

namespace SmartSchool.WebAPI.Helpers
{
    public static class DateTimeExtensions
    {
        public static int GetCurrentAge(this string dateTime)
        {
            DateTime objData = Convert.ToDateTime(dateTime);
            var currentDate = DateTime.UtcNow;
            int age = currentDate.Year - objData.Year;

            if(currentDate < objData.AddYears(age))
                age--;

            return age;
        }
    }
}
using System;

namespace API.Extensions
{
    public static class CalculateAge
    {
        public static int CalAge(this DateTime date)
        {
           var today= DateTime.Today;
           var age= today.Year-date.Year;
           //if (date.Date > today.AddYears(-age)) age--;
           return age ;
        }
    }
}
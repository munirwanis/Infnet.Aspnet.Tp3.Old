using System;
using System.ComponentModel.DataAnnotations;

namespace Infnet.Aspnet.Tp3.Attributes
{
    public class CustomDateRangeAttribute : RangeAttribute
    {
        public CustomDateRangeAttribute(int daysCount) :
            base(typeof(DateTime), DateTime.Now.ToString(), DateTime.Now.AddDays(daysCount).ToString()) {}
    }
}
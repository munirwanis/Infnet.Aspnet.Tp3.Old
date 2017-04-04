using Infnet.Aspnet.Tp3.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Infnet.Aspnet.Tp3.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class StartLessThanEndAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = (LoanViewModel)value;
            return model.LoanDate < model.DevolutionDate;
        }
    }
}
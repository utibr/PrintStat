using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace PrintStat.Models.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IsNumericAttribute: ValidationAttribute
    {

    
      protected override ValidationResult IsValid(object value, ValidationContext validationContext)
      {
          if (value != null)
          {

              decimal val;
              var isNumeric = decimal.TryParse(value.ToString(), out val);

              if (!isNumeric)
              {
                  return new ValidationResult("Введите числовое значение");
              }
          }
          return ValidationResult.Success;
      }
    }
}
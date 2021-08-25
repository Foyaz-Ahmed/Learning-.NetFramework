using System;
using System.ComponentModel.DataAnnotations;

namespace DataAnnotationMVC.Models
{
    public class ValidateBirthDate : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime _birthDate = Convert.ToDateTime(value);
            DateTime minDate = Convert.ToDateTime("01/01/1998");
            DateTime maxDate = Convert.ToDateTime("01/01/2008");

            if (_birthDate > minDate && _birthDate < maxDate)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessage);
        }
    }
}
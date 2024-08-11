using System.ComponentModel.DataAnnotations;

namespace api_remember_it.DTOs.ValidationAttributes
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private int _minimumAge;
        public MinimumAgeAttribute(int minimumAge) 
        {
            _minimumAge = minimumAge;
            base.ErrorMessage = "The user is younger than " + _minimumAge + " years old";
        }

        public override bool IsValid(object? value)
        {
            if (DateTime.TryParse(value.ToString(), out DateTime date))
            {
                return date.AddYears(_minimumAge) < DateTime.Now;
            }
            return false;
        }
    }
}

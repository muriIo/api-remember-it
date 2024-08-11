using System.ComponentModel.DataAnnotations;

namespace api_remember_it.DTOs.ValidationAttributes
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private int _minimumAge;
        public MinimumAgeAttribute(int minimumAge) 
        {
            _minimumAge = minimumAge;
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

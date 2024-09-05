using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.Domain
{
    public class CustomAuthorDateAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;
        private readonly DateTime _maxDate;

        public CustomAuthorDateAttribute()
        {
            _minDate = new DateTime(1900, 1, 1);
            _maxDate = DateTime.Now.AddYears(-20);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateValue)
            {
                if (dateValue < _minDate || dateValue > _maxDate)
                {
                    return new ValidationResult(string.Format(ErrorMessage ?? "The date of Author's birth must be between {0:yyyy-MM-dd} and {1:yyyy-MM-dd}.", _minDate, _maxDate));
                }
            }
            return ValidationResult.Success;
        }
    }

}

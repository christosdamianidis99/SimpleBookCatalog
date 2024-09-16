using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class DecimalRangeAttribute : ValidationAttribute
    {
        private readonly double _min;
        private readonly double _max;

        public DecimalRangeAttribute(double min, double max)
        {
            _min = min;
            _max = max;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success; // Or ValidationResult.Fail if null should be invalid
            }

            if (value is decimal decimalValue)
            {
                // Convert double to decimal for comparison
                decimal minDecimal = (decimal)_min;
                decimal maxDecimal = (decimal)_max;

                if (decimalValue < minDecimal || decimalValue > maxDecimal)
                {
                    return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                }

                return ValidationResult.Success;
            }

            return new ValidationResult("Invalid data type.");
        }

        public override string FormatErrorMessage(string name)
        {
            return $"The field {name} must be between {_min} and {_max}.";
        }
    }




}

using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
namespace SimpleBookCatalog.Domain.Attributes
{


    public class PasswordComplexityAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string password)
            {
                return new ValidationResult("Password is required.");
            }

            // Check length
            if (password.Length < 8)
            {
                return new ValidationResult("Password must be at least 8 characters long.");
            }

            // Check for at least one letter
            if (!Regex.IsMatch(password, @"[a-zA-Z]"))
            {
                return new ValidationResult("Password must contain at least one letter.");
            }

            // Check for at least one number
            if (!Regex.IsMatch(password, @"\d"))
            {
                return new ValidationResult("Password must contain at least one number.");
            }

            // Check for at least one symbol
            if (!Regex.IsMatch(password, @"[\W_]"))
            {
                return new ValidationResult("Password must contain at least one symbol.");
            }

            // Check for at least one uppercase letter
            if (!Regex.IsMatch(password, @"[A-Z]"))
            {
                return new ValidationResult("Password must contain at least one uppercase letter.");
            }

            return ValidationResult.Success;
        }
    }

}

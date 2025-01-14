using System.ComponentModel.DataAnnotations;

namespace SimpleBookCatalog.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide an email or username.")]
        [MaxLength(100, ErrorMessage = "Email/Username cannot exceed 100 characters.")]
        public string? EmailOrUsername { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string? Password { get; set; }
    }
}

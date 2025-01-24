using SimpleBookCatalog.Domain.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleBookCatalog.Domain.Entities
{
    public class UserAccount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_name")]
        [MaxLength(100)]
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Column("email")]
        [MaxLength(150)]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Column("password")]
        [MaxLength(100)]
        [Required]
        [PasswordComplexityAttribute]
        public string Password { get; set; } = string.Empty;

        [Column("role")]
        [MaxLength(20)]
        [Required]
        public string Role { get; set; } = "User";

        // New field: is_verified
        [Column("is_verified")]
        [Required]
        public bool IsVerified { get; set; } = false;

        // New field: verification_token
        [Column("verification_token")]
        [MaxLength(250)]
        public string? VerificationToken { get; set; }
    }
}

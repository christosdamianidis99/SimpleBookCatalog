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
        public string Password { get; set; } = string.Empty;

        [Column("role")]
        [MaxLength(20)]
        [Required]
        public string Role { get; set; } = "User";
    }
}

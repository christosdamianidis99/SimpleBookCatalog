using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public string? UserName { get; set; }

        [Column("password")]
        [MaxLength(100)]    
        public string? Password { get; set; }

        [Column("role")]
        [MaxLength(20)]
        public string? Role { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.Domain.Entities
{
    [Table("LoginActivities")] // Ensures table name consistency
    public class LoginActivity
    {
        [Key]
        public int Id { get; set; } // Primary key

        [Required]
        public string UserName { get; set; } = string.Empty; // Username of the user who logged in

        [Required]
        public string IPAddress { get; set; } = string.Empty; // IP Address of the login attempt

        [Required]
        public DateTime Date { get; set; } // Timestamp of login attempt

        [Required]
        public bool IsSuccessful { get; set; } // Was the login successful?
    }
}

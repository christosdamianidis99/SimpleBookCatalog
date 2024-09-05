using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.Domain.Entities
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Name")]

        public string Name { get; set; }

        [StringLength(200)]
        [DisplayName("Address")]

        public string? Address { get; set; }

        [Url(ErrorMessage = "Invalid URL")]
        [DisplayName("Website")]
        public string? Website { get; set; }

        public ICollection<Book>? Books { get; set; }
    }

}

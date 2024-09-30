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
        [Required(ErrorMessage ="Please provide Publisher's name")]
        [StringLength(100)]
        [DisplayName("Name")]
        [IsForForm(true)]
        [isStringWithoutNumbers(true)]

        public string Name { get; set; }

        [StringLength(200)]
        [DisplayName("Address")]
        [IsForForm(true)]
        [Required(ErrorMessage = "Please provide Publisher's address")]
        public string? Address { get; set; }

        [Url(ErrorMessage = "Invalid URL")]
        [DisplayName("Website")]
        [IsForForm(true)]
        public string? Website { get; set; }

        public ICollection<Book>? Books { get; set; }

        public Boolean isMock = false;

    }

}

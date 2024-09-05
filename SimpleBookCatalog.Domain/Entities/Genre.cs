﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.Domain.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Name")]

        public string Name { get; set; }

        public ICollection<Book>? Books { get; set; }
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.Domain.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings =false, ErrorMessage ="Please provide User Name")]
        public string? UserName { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Please provide Password")]
        public string? Password { get; set; }
    }
}

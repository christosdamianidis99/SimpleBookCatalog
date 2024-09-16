
using SimpleBookCatalog.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace SimpleBookCatalog.Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage="Please provide first name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Only letters are allowed")]
        [StringLength(100)]
        [DisplayName("First name")]
        [isStringWithoutNumbers(true)]
        [IsForForm(true)]
        public string? FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "Only letters are allowed")]
        [Required(ErrorMessage = "Please provide surname")]
        [StringLength(100)]
        [IsForForm(true)]
        [isStringWithoutNumbers(true)]
        [DisplayName("Surname")]

        public string? Surname { get; set; }

        [DisplayName("Date of Birth")]
        [CustomAuthorDate(ErrorMessage = "The date of Author's birth must be between 1-1-1900 and {1}")]
        [IsForForm(true)]
        [Required(ErrorMessage = "Please provide a date of birth")]
        public DateTime? DateOfBirth { get; set; }

        public ICollection<Book>? Books { get; set; }

        [StringLength(2000, ErrorMessage = "Biography is too long")]
        [DisplayName("Biography")]
        [IsForForm(true)]
        public string? Biography { get; set; }

        [DisplayName("Nationality")]
        [Required(ErrorMessage = "Please provide a Nationality")]
        [IsForForm(true)]
        [EnumDataType(typeof(Nationality), ErrorMessage = "Please select a valid language")]
        public Nationality AuthorNationality { get; set; } // Updated from string to enum


        [IsForForm(false)]
        public string FullName
        {
            get
            {
                return $"{FirstName} {Surname}";
            }
        }
    }
}

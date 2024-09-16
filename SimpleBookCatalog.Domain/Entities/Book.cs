

using SimpleBookCatalog.Domain.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SimpleBookCatalog.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please provide a title")]
        [StringLength(100)]
        [DisplayName("Title")]
        [IsForForm(true)]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please provide a publication date")]
        [CustomBookDate(ErrorMessage = "The publication date must be between 01-01-1900 and today.")]
        [DisplayName("Publication Date")]
        [IsForForm(true)]
        public DateTime? PublicationDate { get; set; }

        [Required]
        [EnumDataType(typeof(Category), ErrorMessage = "Please select a category")]
        [DisplayName("Category")]
        [IsForForm(true)]
        public Category Category { get; set; }

        
        [EnumDataType(typeof(BookColors), ErrorMessage = "Please select a color")]
        [DisplayName("Books colors")]
        [IsForForm(true)]
        public BookColors BookColors { get; set; }

        [Required(ErrorMessage = "Please enter the number of book's pages")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of pages must be greater than 0")]
        [DisplayName("Number of pages")]
        [IsForForm(true)]
        public int? NumberOfPages { get; set; }

        [Required(ErrorMessage = "Please enter how many books sold")]
        [DisplayName("Number of books sold")]
        [IsForForm(true)]
        public int? NumberOfBooksSold { get; set; }



        [Required(ErrorMessage = "Please specify the language")]
        [StringLength(50)]
        [IsForForm(true)]
        [isStringWithoutNumbers(true)]
        public string? Language { get; set; }

        [Required(ErrorMessage ="Please enter a summary")]
        [StringLength(1000, ErrorMessage = "Summary is too long")]
        [IsForForm(true)]
        
        public string? Summary { get; set; }

        [Required(ErrorMessage = "Please enter the book's price")]
        [Range(0.0,9999.0, ErrorMessage ="Price value must be between 0-9999")]
        [IsForForm(true)]
        public decimal? Price { get; set; }


        [IsForForm(false)]
        [Required]

        [Range(1, int.MaxValue,ErrorMessage = "Please provide an Author")]

        public int AuthorId { get; set; }



        public Author? Author { get; set; }





        [IsForForm(false)]

        [Required]
        [Range(1, int.MaxValue,ErrorMessage = "Please provide a Genre")]
        public int GenreId { get; set; }

       
        

        public Genre? Genre { get; set; }






        [IsForForm(false)]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please provide a Publisher")]

        public int PublisherId { get; set; }




        public Publisher? Publisher { get; set; }


    }
}

namespace SimpleBookCatalog
{
    using SimpleBookCatalog.Domain.Entities;
    using SimpleBookCatalog.Domain.Enums;
    using System;

    public class MockAuthorData
    {
        public static List<Author> GetMockAuthors()
        {
            return new List<Author>
        {
            new Author
            {
                Id = 1001,
                FirstName = "Mark",
                Surname = "Twain",
                DateOfBirth = new DateTime(1835, 11, 30),
                Biography = "Mark Twain, born Samuel Clemens, was an American author and humorist known for works such as 'The Adventures of Tom Sawyer' and 'Adventures of Huckleberry Finn.'",
                AuthorNationality = Nationality.American,
                isMock=true
            },
            new Author
            {
                Id = 1002,
                FirstName = "F. Scott",
                Surname = "Fitzgerald",
                DateOfBirth = new DateTime(1896, 9, 24),
                Biography = "F. Scott Fitzgerald was an American novelist and short-story writer, widely regarded as one of the greatest American writers of the 20th century. His most famous novel is 'The Great Gatsby.'",
                AuthorNationality = Nationality.American,
                isMock=true
            },
            new Author
            {
                Id = 1003,
                FirstName = "Gabriel",
                Surname = "García Márquez",
                DateOfBirth = new DateTime(1927, 3, 6),
                Biography = "Gabriel García Márquez was a Colombian novelist and short story writer, widely considered one of the most significant authors of the 20th century. He was awarded the Nobel Prize for Literature in 1982.",
                AuthorNationality = Nationality.Italian,
                isMock=true
            },
            new Author
            {
                Id = 1004,
                FirstName = "Herman",
                Surname = "Melville",
                DateOfBirth = new DateTime(1819, 8, 1),
                Biography = "Herman Melville was an American novelist, short story writer, and poet of the American Renaissance period. His best-known works include 'Moby Dick' and 'Bartleby, the Scrivener.'",
                AuthorNationality = Nationality.American,
                isMock=true
            },
            new Author
            {
                Id = 1005,
                FirstName = "Jane",
                Surname = "Austen",
                DateOfBirth = new DateTime(1775, 12, 16),
                Biography = "Jane Austen was an English novelist known primarily for her six major novels which critique the British landed gentry at the end of the 18th century. Her novels include 'Pride and Prejudice' and 'Sense and Sensibility.'",
                AuthorNationality = Nationality.British,
                isMock=true
                
            }
        };
        }
    }

}

namespace SimpleBookCatalog
{
    using SimpleBookCatalog.Domain.Entities;
    using SimpleBookCatalog.Domain.Enums;
    using System;
    using System.Collections.Generic;




public class MockBookData
    {
        public static List<Book> GetMockBooks(List<Author> authors, List<Genre> genres, List<Publisher> publishers)
        {
            return new List<Book>
        {
            new Book
            {
                Id = 1001,
                Title = "The Great Adventure",
                PublicationDate = new DateTime(2010, 5, 10),
                Category = Category.Science,
                BookColors = BookColors.Ciel,
                NumberOfPages = 320,
                NumberOfBooksSold = 50000,
                Language = Language.English,
                Summary = "An epic tale of adventure and discovery across uncharted lands.",
                Price = 19.99m,
                AuthorId = authors[0].Id,
                Author = authors[0],
                GenreId = genres[0].Id,
                Genre = genres[0],
                PublisherId = publishers[0].Id,
                Publisher = publishers[0],
                isMock = true
            },
            new Book
            {
                Id = 1002,
                Title = "Science and the Universe",
                PublicationDate = new DateTime(2015, 10, 20),
                Category = Category.Science,
                BookColors = BookColors.Green,
                NumberOfPages = 280,
                NumberOfBooksSold = 75000,
                Language = Language.English,
                Summary = "A deep dive into the mysteries of the cosmos and scientific advancements.",
                Price = 25.50m,
                AuthorId = authors[1].Id,
                Author = authors[1],
                GenreId = genres[1].Id,
                Genre = genres[1],
                PublisherId = publishers[1].Id,
                Publisher = publishers[1],
                isMock = true
            },
            new Book
            {
                Id = 1003,
                Title = "Cooking with Passion",
                PublicationDate = new DateTime(2020, 3, 14),
                Category = Category.Fitness,
                BookColors = BookColors.Red,
                NumberOfPages = 150,
                NumberOfBooksSold = 40000,
                Language = Language.French,
                Summary = "A collection of unique recipes inspired by cultures around the world.",
                Price = 18.75m,
                AuthorId = authors[2].Id,
                Author = authors[2],
                GenreId = genres[2].Id,
                Genre = genres[2],
                PublisherId = publishers[2].Id,
                Publisher = publishers[2],
                isMock = true
            },
            new Book
            {
                Id = 1004,
                Title = "Digital Transformation",
                PublicationDate = new DateTime(2018, 11, 5),
                Category = Category.Technology,
                BookColors = BookColors.Black,
                NumberOfPages = 400,
                NumberOfBooksSold = 120000,
                Language = Language.German,
                Summary = "An in-depth guide to the evolution of technology in the digital age.",
                Price = 32.99m,
                AuthorId = authors[3].Id,
                Author = authors[3],
                GenreId = genres[3].Id,
                Genre = genres[3],
                PublisherId = publishers[3].Id,
                Publisher = publishers[3],
                isMock = true
            },
            new Book
            {
                Id = 1005,
                Title = "Mystery of the Lost Island",
                PublicationDate = new DateTime(2022, 1, 15),
                Category = Category.Science,
                BookColors = BookColors.Purple,
                NumberOfPages = 350,
                NumberOfBooksSold = 85000,
                Language = Language.Spanish,
                Summary = "A thrilling mystery involving the secrets of a hidden island.",
                Price = 22.99m,
                AuthorId = authors[4].Id,
                Author = authors[4],
                GenreId = genres[4].Id,
                Genre = genres[4],
                PublisherId = publishers[4].Id,
                Publisher = publishers[4],
                isMock = true
            }
        };
        }
    }

}

namespace SimpleBookCatalog
{
    using SimpleBookCatalog.Domain.Entities;
    using System;
    using System.Collections.Generic;

    public class MockPublisherData
    {
        public static List<Publisher> GetMockPublishers()
        {
            return new List<Publisher>
        {
            new Publisher
            {
                Id = 1001,
                Name = "Penguin Random House",
                Address = "1745 Broadway, New York, NY 10019, USA",
                Website = "https://www.penguinrandomhouse.com",
                Books = new List<Book>{},
                isMock=true
            },
            new Publisher
            {
                Id = 1002,
                Name = "HarperCollins",
                Address = "195 Broadway, New York, NY 10007, USA",
                Website = "https://www.harpercollins.com",
                Books = new List<Book>{},
                isMock=true
            },
            new Publisher
            {
                Id = 1003,
                Name = "Simon & Schuster",
                Address = "1230 Avenue of the Americas, New York, NY 10020, USA",
                Website = "https://www.simonandschuster.com",
                Books = new List<Book>{},
                isMock=true
            },
            new Publisher
            {
                Id = 1004,
                Name = "Hachette Book Group",
                Address = "1290 Avenue of the Americas, New York, NY 10104, USA",
                Website = "https://www.hachettebookgroup.com",
                Books = new List<Book>{},
                isMock=true
            },
            new Publisher
            {
                Id = 1005,
                Name = "Macmillan Publishers",
                Address = "120 Broadway, New York, NY 10271, USA",
                Website = "https://us.macmillan.com",
                Books = new List<Book>{},
                isMock=true
            }
        };
        }


        public static List<Publisher> LinkPublishersWithBooks(List<Book> books, List<Publisher> publishers)
        {
            int i = 0;
            foreach(var publisher in publishers)
            {
                foreach(var book in books)
                {
                    publisher.Books.Add(books[i]);
                    break;
                }
                i++;
            }
            return publishers;
        }
    }

}



using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Application.Interfaces;
using SimpleBookCatalog.Domain.Entities;

namespace SimpleBookCatalog.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly SimpleBookCatalogDbContext context;
        public BookRepository(IDbContextFactory<SimpleBookCatalogDbContext> factory)
        {
            context = factory.CreateDbContext();
        }

        public async Task AddAsync(Book book)
        {
            context.Books.Add(book);
            await context.SaveChangesAsync();
        }


        public async Task<List<Book>> GetAllAsync()
        {
            var books = await context.Books
                .Include(a => a.Author)
                .Include(b => b.Publisher)
                .Include(c => c.Genre)
                .ToListAsync();
            return books;
        }

 

        public async Task<Book> GetByIdAsync(int id)
        {
            
            var book = await context.Books.Include(a=>a.Author).FirstOrDefaultAsync(e => e.Id == id);
  
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
           context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            // Retrieve the entity from the database
            var entity = await context.Books.FindAsync(id);

            // Check if the entity was found
            if (entity == null)
            {
                throw new KeyNotFoundException("The entity with the specified ID was not found.");
            }

            // Remove the entity
            context.Books.Remove(entity);

            // Save changes
            await context.SaveChangesAsync();
        }

    }
}

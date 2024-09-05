using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Application.Interfaces;
using SimpleBookCatalog.Domain.Entities;


namespace SimpleBookCatalog.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly SimpleBookCatalogDbContext _context;

        public AuthorRepository(IDbContextFactory<SimpleBookCatalogDbContext> factory)
        {
            _context = factory.CreateDbContext();
        }
        public async Task AddAsync(Author author)
        {
          _context.Authors.Add(author);
            await _context.SaveChangesAsync();
        }



        public async Task<List<Author>> GetAllAsync()
        {
            var authors = await _context.Authors
                .Include(e => e.Books)
                .ToListAsync();
            return authors;
        }

        public async Task<List<Author>> GetAllAsyncWithPublishers()
        {
            var authors = await _context.Authors
    .Include(e => e.Books)
    .ThenInclude(e=>e.Publisher)
    .ToListAsync();
            return authors;
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("ID must be greater than zero.", nameof(id));
            }

            var author = await _context.Authors.FirstOrDefaultAsync(e => e.Id == id);
            if (author == null)
            {
                // Handle the case where no author is found
                // This could involve throwing an exception or returning a default value
                throw new InvalidOperationException($"No author found with ID {id}.");
            }

            return author;
        }


        public async Task UpdateAsync(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Books.FindAsync(id);

            if (entity == null)
            {
                throw new KeyNotFoundException("The entity with the specified ID was not found.");
            }

            _context.Books.Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}

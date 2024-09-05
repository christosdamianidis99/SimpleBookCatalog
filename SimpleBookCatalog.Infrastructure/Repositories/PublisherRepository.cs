using Microsoft.EntityFrameworkCore;
using SimpleBookCatalog.Application.Interfaces;
using SimpleBookCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.Infrastructure.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly SimpleBookCatalogDbContext context;

        public PublisherRepository(IDbContextFactory<SimpleBookCatalogDbContext> factory)
        {
            context = factory.CreateDbContext();
        }
        public async Task AddAsync(Publisher publisher)
        {
            context.Publishers.Add(publisher);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Publishers.FindAsync(id);

            if (entity==null)
            {
                throw new KeyNotFoundException("The entity with the specified ID was not found.");
            }

            context.Publishers.Remove(entity);
            await context.SaveChangesAsync();   
        }

        public async Task<List<Publisher>> GetAllAsync()
        {
            var publishers = await context.Publishers
                .Include(e => e.Books)
                .ToListAsync();
            return publishers;
        }

        public async Task<List<Publisher>> GetAllAsyncWithAuthors()
        {
            var publishers = await context.Publishers
                .Include(e => e.Books)
                .ThenInclude(e=>e.Author)
                .ToListAsync();
            return publishers;
        }
        public async Task<Publisher> GetByIdAsync(int id)
        {
            if (id < 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            var publisher = await context.Publishers.FirstOrDefaultAsync(e => e.Id == id);
            if (publisher == null)
            {
                throw new InvalidOperationException($"No publisher found with ID{id}.");
            }

            return publisher;
        }

        public async Task UpdateAsync(Publisher publisher)
        {
         context.Entry(publisher).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}

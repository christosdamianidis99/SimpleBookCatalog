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
    public class GenreRepository : IGenreRepository
    {
        private readonly SimpleBookCatalogDbContext context;

        public GenreRepository(IDbContextFactory<SimpleBookCatalogDbContext> factory)
        {
            context =factory.CreateDbContext();
        }

        public async Task<List<Genre>> GetAllAsyncWithBooks()
        {
            //var genres = await context.Genres.ToListAsync();
            var genres = await context.Genres
                .Include(g => g.Books)
                    .ThenInclude(b => b.Author)
                .Include(g => g.Books)
                    .ThenInclude(b => b.Publisher).ToListAsync();

            return genres;
        }

        public async Task<List<Genre>> GetAllAsync()
        {
            var genres = await context.Genres.ToListAsync();
           
            return genres;
        }




    }
}

using SimpleBookCatalog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookCatalog.Application.Interfaces
{
    public interface IPublisherRepository
    {
        Task AddAsync(Publisher publisher);

        Task<List<Publisher>> GetAllAsync();
        Task<List<Publisher>> GetAllAsyncWithAuthors();
        Task<Publisher> GetByIdAsync(int id);
        Task UpdateAsync(Publisher publisher);

        Task DeleteAsync(int id);
    }
}

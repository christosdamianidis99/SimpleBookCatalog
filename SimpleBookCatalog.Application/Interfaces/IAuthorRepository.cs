using SimpleBookCatalog.Domain.Entities;


namespace SimpleBookCatalog.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task AddAsync(Author author);
        Task<List<Author>> GetAllAsync();
        Task<List<Author>> GetAllAsyncWithPublishers();
        Task<Author> GetByIdAsync(int id);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}

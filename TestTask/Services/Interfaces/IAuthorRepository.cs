using TestTask.Models;

namespace TestTask.Services.Interfaces
{
    public interface IAuthorRepository
    {
        Task AddAuthorAsync(Author author);
        Task DeleteAuthorAsync(int id);
        Task<List<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task UpdateAuthorAsync(Author author);
    }
}
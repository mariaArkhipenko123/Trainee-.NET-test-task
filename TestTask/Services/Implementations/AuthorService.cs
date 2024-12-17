using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<Author> GetAuthor()
        {
            var books = await _bookRepository.GetAllBooksAsync();
            var authorWithMostExpensiveBook = books
                .OrderByDescending(b => b.Price)
                .Select(b => b.Author)
                .FirstOrDefault();

            return authorWithMostExpensiveBook;
        }

        public async Task<List<Author>> GetAuthors()
        {
            var authors = await _authorRepository.GetAllAuthorsAsync(); 
            var books = await _bookRepository.GetAllBooksAsync();

            var filteredAuthors = authors.Where(author =>
                books.Count(book => book.AuthorId == author.Id && book.PublishDate.Year > 2015) % 2 == 0);

            return filteredAuthors.ToList();
        }
    }
}


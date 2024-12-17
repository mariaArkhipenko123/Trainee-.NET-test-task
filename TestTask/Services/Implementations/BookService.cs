using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> GetBook()
        {
            var books = await _bookRepository.GetAllBooksAsync(); 

            return books
                .OrderByDescending(b => b.Price)
                .FirstOrDefault();
        }

        public async Task<List<Book>> GetBooks()
        {
            var carolusRexReleaseDate = new DateTime(2012, 5, 25);

            var books = await _bookRepository.GetAllBooksAsync(); 

            return books
                .Where(b => b.Title.Contains("Red", StringComparison.OrdinalIgnoreCase)
                             && b.PublishDate > carolusRexReleaseDate)
                .ToList();
        }
    }
}


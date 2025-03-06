
using BooksService.IRepository;
using BooksService.IService;
using BooksService.NewFolder;

namespace BooksService.Service
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Books>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }

        public async Task<Books?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetBookByIdAsync(id);
        }

        public async Task AddBookAsync(Books book)
        {
            await _bookRepository.AddBookAsync(book);
            await _bookRepository.SaveChangesAsync();
        }
    }
}

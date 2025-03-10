
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

        public async Task<Books> UpdateBookAsync(Books book)
        {
            var existingbook = await _bookRepository.GetBookByIdAsync(book.Id);
            if (existingbook == null) 
            {
                throw new Exception("Book is not found");
            }
            var response = await _bookRepository.UpdateBookAsync(book);
            await _bookRepository.SaveChangesAsync();
            return response;
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
            await _bookRepository.SaveChangesAsync();
        }
    }
}

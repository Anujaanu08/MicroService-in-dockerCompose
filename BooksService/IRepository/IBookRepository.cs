using BooksService.NewFolder;

namespace BooksService.IRepository
{
    public interface IBookRepository
    {
        Task<IEnumerable<Books>> GetAllBooksAsync();
        Task<Books?> GetBookByIdAsync(int id);
        Task AddBookAsync(Books book);
        Task SaveChangesAsync();
    }
}

using BooksService.Database;
using BooksService.IRepository;
using BooksService.NewFolder;
using Microsoft.EntityFrameworkCore;
using System;

namespace BooksService.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Books>> GetAllBooksAsync()
        {
            return await _context.AnuBooks.ToListAsync();
        }

        public async Task<Books?> GetBookByIdAsync(int id)
        {
            return await _context.AnuBooks.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddBookAsync(Books book)
        {
            await _context.AnuBooks.AddAsync(book);
        }

        public async Task<Books> UpdateBookAsync(Books book)
        {
            _context.AnuBooks.Update(book);
            return book;
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.AnuBooks.FindAsync(id);
            if (book != null)
            {
                _context.AnuBooks.Remove(book);
            }
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

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
            return await _context.Books.ToListAsync();
        }

        public async Task<Books?> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task AddBookAsync(Books book)
        {
            await _context.Books.AddAsync(book);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}

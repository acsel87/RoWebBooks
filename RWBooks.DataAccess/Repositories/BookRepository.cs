using Microsoft.EntityFrameworkCore;
using RWBooks.DataAccess.Context;
using RWBooks.DataAccess.Entities;
using RWBooks.Domain.Models;

namespace RWBooks.DataAccess.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BookListItem>> GetBookListItems()
        {
            return await _context.Books
                .Select(b => new BookListItem { Id = b.Id, Title = b.Title })
                .ToListAsync();
        }
    }
}

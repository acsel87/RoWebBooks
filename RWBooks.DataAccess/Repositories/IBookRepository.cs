using RWBooks.DataAccess.Entities;
using RWBooks.Domain.Models;

namespace RWBooks.DataAccess.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<BookListItem>> GetBookListItems();
    }
}

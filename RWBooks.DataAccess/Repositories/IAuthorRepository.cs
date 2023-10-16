using RWBooks.DataAccess.Entities;
using RWBooks.Domain.Models;

namespace RWBooks.DataAccess.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<IEnumerable<AuthorListItem>> GetAuthorListItems();        
    }
}

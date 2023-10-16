using Microsoft.EntityFrameworkCore;
using RWBooks.DataAccess.Context;
using RWBooks.DataAccess.Entities;
using RWBooks.Domain.Models;

namespace RWBooks.DataAccess.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {           
        }

        public async Task<IEnumerable<AuthorListItem>> GetAuthorListItems()
        {
            return await _context.Authors
                .Select(a => new AuthorListItem { Id = a.Id, Name = a.Name })
                .ToListAsync();
        }
    }
}

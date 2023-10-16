using Microsoft.EntityFrameworkCore;
using RWBooks.DataAccess.Context;
using RWBooks.DataAccess.CustomExceptions;
using RWBooks.DataAccess.Entities;
using System.Linq.Expressions;

namespace RWBooks.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T?> GetById(Guid id)
        {
            return  await _context.Set<T>().FindAsync(id);
        }      

        public async Task<IEnumerable<T>> GetFiltered(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().AsNoTracking().Where(filter).ToListAsync();
        }

        public async Task<int> Count()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> CountFiltered(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().CountAsync(filter);
        }

        public Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return Task.CompletedTask;
        }

        public Task Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }       

        public Task SoftDelete(T entity)
        {
            entity.IsDeleted = true;
            _context.Set<T>().Update(entity);
            return Task.CompletedTask;
        }

        public async Task<bool> SoftDelete(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return false;
            }

            entity.IsDeleted = true;
            _context.Set<T>().Update(entity);
            return true;
        }
    }
}

using System.Linq.Expressions;

namespace RWBooks.DataAccess.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetById(Guid id);       
        Task<IEnumerable<T>> GetFiltered(Expression<Func<T, bool>> filter);
        Task<int> Count();
        Task<int> CountFiltered(Expression<Func<T, bool>> filter);
        Task Add(T entity);
        Task Update(T entity);
        Task SoftDelete(T entity);
        Task<bool> SoftDelete(Guid id);
    }
}

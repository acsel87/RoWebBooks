using RWBooks.DataAccess.Entities;

namespace RWBooks.DataAccess.Repositories
{
    public interface IUnitOfWork : IDisposable
    { 
        IAuthorRepository Authors { get; }
        IBookRepository Books { get; }
        Task<int> Commit();
    }

}

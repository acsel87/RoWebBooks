using RWBooks.DataAccess.Context;

namespace RWBooks.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;        
        private readonly Lazy<IAuthorRepository> _authorRepository;
        private readonly Lazy<IBookRepository> _bookRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;           

            _authorRepository = new Lazy<IAuthorRepository>(() => new AuthorRepository(_context));
            _bookRepository = new Lazy<IBookRepository>(() => new BookRepository(_context));
        }               

        public IAuthorRepository Authors
        {
            get { return _authorRepository.Value; }
        }

        public IBookRepository Books
        {
            get { return _bookRepository.Value; }
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

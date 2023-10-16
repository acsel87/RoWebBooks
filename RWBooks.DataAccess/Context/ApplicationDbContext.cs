using Microsoft.EntityFrameworkCore;
using RWBooks.DataAccess.Configurations;
using RWBooks.DataAccess.Entities;

namespace RWBooks.DataAccess.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorConfiguration).Assembly);            
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }       
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RWBooks.DataAccess.Entities;
using System.Reflection.Emit;

namespace RWBooks.DataAccess.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.Id)
                .HasDefaultValueSql("newsequentialid()");

            builder.Property(a => a.Name)
                .IsRequired()
            .HasMaxLength(50);

            builder.HasIndex(a => a.Name);

            builder.HasQueryFilter(a => !a.IsDeleted);
        }
    }
}

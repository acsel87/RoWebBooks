using RWBooks.DataAccess.Entities;
using RWBooks.Domain.Models;

namespace RWBooks.Service.Extensions
{
    public static class Mapper
    {
        public static Author ToAuthor(this AuthorInfo authorInfo)
        {
            if (authorInfo == null) throw new ArgumentNullException(nameof(authorInfo));

            return new Author
            {
                Id = authorInfo.Id,
                Name = authorInfo.Name
            };
        }

        public static AuthorInfo ToAuthorInfo(this Author author)
        {
            if (author == null) throw new ArgumentNullException(nameof(author));

            return new AuthorInfo
            {
                Id = author.Id,
                Name = author.Name
            };
        }
    }
}

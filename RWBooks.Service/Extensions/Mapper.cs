using RWBooks.DataAccess.Entities;
using RWBooks.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

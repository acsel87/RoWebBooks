using RWBooks.App.Models;
using RWBooks.DataAccess.Entities;

namespace RWBooks.App.Extensions
{
    public static class Mapper
    {
        public static Author ToAuthor(this AuthorCreateViewModel authorCreateViewModel)
        {
            if (authorCreateViewModel == null) throw new ArgumentNullException(nameof(authorCreateViewModel));

            return new Author
            {
                Name = authorCreateViewModel.Name
            };
        }

        public static AuthorCreateViewModel ToAuthorCreateViewModel(this Author author)
        {
            if (author == null) throw new ArgumentNullException(nameof(author));

            return new AuthorCreateViewModel
            {
                Name = author.Name
            };
        }
    }
}

namespace RWBooks.Domain.Models
{
    public class AuthorList
    {
        public required IEnumerable<AuthorListItem> AuthorListItems { get; set; }
    }
}

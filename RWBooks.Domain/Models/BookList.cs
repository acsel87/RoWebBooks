namespace RWBooks.Domain.Models
{
    public class BookList
    {
        public required IEnumerable<BookListItem> BookListItems { get; set; }
    }
}

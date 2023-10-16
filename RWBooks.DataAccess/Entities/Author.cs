using System.ComponentModel.DataAnnotations;

namespace RWBooks.DataAccess.Entities
{
    public class Author : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }     
        public List<Book> Books { get; set; } = new List<Book>();
    }
}

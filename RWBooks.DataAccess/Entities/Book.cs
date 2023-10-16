using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RWBooks.DataAccess.Entities
{
    public class Book : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required Guid AuthorId { get; set; }     

        [ForeignKey(nameof(AuthorId))]
        public required Author Author { get; set; }
    }
}
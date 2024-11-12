using BookStore.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Entities
{
    public class AuthorEntity
    {
        [Key]
        public Guid Uid { get; set; }

        [Required]
        [StringLength(Author.MAX_FULLNAME_LENGTH)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public DateOnly Birthday { get; set; }

        public List<BookEntity> Books { get; set; } = [];
    }
}

using BookStore.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Data.Entities
{
    public class BookEntity
    {
        [Key]
        public Guid Uid { get; set; }

        [Required]
        [StringLength(Book.MAX_TITLE_LENGTH)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public uint PublishedYear { get; set; }

        [Required]
        public Book.GenreType Genre { get; set; }

        [Required]
        public Guid AuthorUid { get; set; }
        
        public AuthorEntity Author { get; set; } = null!;
    }
}

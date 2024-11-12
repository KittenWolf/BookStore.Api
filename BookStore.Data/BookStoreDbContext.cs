using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) 
        : DbContext(options)
    {
        public DbSet<BookEntity> Books { get; set; }
        public DbSet<AuthorEntity> Authors { get; set; }
    }
}

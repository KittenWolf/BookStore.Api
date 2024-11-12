using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories
{
    public class BooksRepository(BookStoreDbContext dbContext) : IBooksRepository
    {
        private readonly BookStoreDbContext _dbContext = dbContext;

        public async Task<Guid> Create(Guid uid, string title, uint publishedYear, Book.GenreType genre, Guid authorUid)
        {
            var bookEntity = new BookEntity()
            {
                Uid = uid,
                Title = title,
                PublishedYear = publishedYear,
                Genre = genre,
                AuthorUid = authorUid
            };

            await _dbContext.AddAsync(bookEntity);
            await _dbContext.SaveChangesAsync();

            return uid;
        }

        public async Task<List<Book>> GetAll()
        {
            var bookEntities = await _dbContext.Books
                .AsNoTracking()
                .ToListAsync();

            var books = bookEntities
                .Select(x => Book.Create(x.Uid, x.Title, x.PublishedYear, x.Genre, x.AuthorUid).Book)
                .ToList();

            return books;
        }

        public async Task<Book?> GetByUid(Guid uid)
        {
            var bookEntity = await _dbContext.Books
                .Where(x => x.Uid == uid)
                .FirstOrDefaultAsync();

            if (bookEntity == null)
            {
                return null;
            }

            var book = Book.Create(bookEntity.Uid, bookEntity.Title, bookEntity.PublishedYear, bookEntity.Genre, bookEntity.AuthorUid).Book;

            return book;
        }

        public async Task<Guid> Update(Guid uid, string title, uint publishedYear, Book.GenreType genre, Guid authorUid)
        {
            await _dbContext.Books
                .Where(x => x.Uid == uid)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(p => p.Title, title)
                    .SetProperty(p => p.Genre, genre)
                    .SetProperty(p => p.PublishedYear, publishedYear)
                    .SetProperty(p => p.AuthorUid, authorUid));

            return uid;
        }

        public async Task<Guid> Delete(Guid uid)
        {
            await _dbContext.Books
                .Where(x => x.Uid == uid)
                .ExecuteDeleteAsync();

            return uid;
        }
    }
}

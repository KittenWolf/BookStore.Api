using BookStore.Core.Abstractions;
using BookStore.Core.Models;
using BookStore.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data.Repositories
{
    public class AuthorsRepository(BookStoreDbContext dbContext) : IAuthorsRepository
    {
        private readonly BookStoreDbContext _dbContext = dbContext;

        public async Task<Guid> Create(Guid uid, string fullName, DateOnly birthday)
        {
            var authorEntity = new AuthorEntity()
            {
                Uid = uid,
                FullName = fullName,
                Birthday = birthday
            };

            await _dbContext.AddAsync(authorEntity);
            await _dbContext.SaveChangesAsync();

            return uid;
        }

        public async Task<List<Author>> GetAll()
        {
            var authorsEntities = await _dbContext.Authors
                .AsNoTracking()
                .ToListAsync();

            var authors = authorsEntities
                .Select(x => Author.Create(x.Uid, x.FullName, x.Birthday).Author)
                .ToList();

            return authors;
        }

        public async Task<Author?> GetByUid(Guid uid)
        {
            var authorEntity = await _dbContext.Authors
                .Where(x => x.Uid == uid)
                .FirstOrDefaultAsync();

            if (authorEntity == null)
            {
                return null;
            }

            var author = Author.Create(authorEntity.Uid, authorEntity.FullName, authorEntity.Birthday).Author;

            return author;
        }

        public async Task<Guid> Update(Guid uid, string fullName, DateOnly birthday)
        {
            await _dbContext.Authors
                .Where(x => x.Uid == uid)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(p => p.FullName, fullName)
                    .SetProperty(p => p.Birthday, birthday));

            return uid;
        }

        public async Task<Guid> Delete(Guid uid)
        {
            await _dbContext.Authors
                .Where(x => x.Uid == uid)
                .ExecuteDeleteAsync();

            return uid;
        }
    }
}

using BookStore.Core.Abstractions;
using BookStore.Core.Models;

namespace BookStore.Application.Services
{
    public class AuthorsService(IAuthorsRepository authorsRepository) : IAuthorsService
    {
        private readonly IAuthorsRepository _authorsRepository = authorsRepository;

        public async Task<List<Author>> GetAllAuthors()
        {
            return await _authorsRepository.GetAll();
        }

        public async Task<Author?> GetAuthorByUid(Guid uid)
        {
            return await _authorsRepository.GetByUid(uid);
        }

        public async Task<Guid> CreateAuthor(Author author)
        {
            return await _authorsRepository.Create(author.Uid, author.FullName, author.Birthday);
        }

        public async Task<Guid> UpdateAuthor(Guid uid, string fullName, DateOnly birthday)
        {
            return await _authorsRepository.Update(uid, fullName, birthday);
        }

        public async Task<Guid> DeleteAuthor(Guid uid)
        {
            return await _authorsRepository.Delete(uid);
        }
    }
}

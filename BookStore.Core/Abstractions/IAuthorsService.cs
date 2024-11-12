using BookStore.Core.Models;

namespace BookStore.Core.Abstractions
{
    public interface IAuthorsService
    {
        Task<Guid> CreateAuthor(Author author);
        Task<Guid> DeleteAuthor(Guid uid);
        Task<List<Author>> GetAllAuthors();
        Task<Author?> GetAuthorByUid(Guid uid);
        Task<Guid> UpdateAuthor(Guid uid, string fullName, DateOnly birthday);
    }
}
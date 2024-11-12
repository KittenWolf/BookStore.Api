using BookStore.Core.Models;

namespace BookStore.Core.Abstractions
{
    public interface IAuthorsRepository
    {
        Task<Guid> Create(Guid uid, string fullName, DateOnly birthday);
        Task<Guid> Delete(Guid uid);
        Task<List<Author>> GetAll();
        Task<Author?> GetByUid(Guid uid);
        Task<Guid> Update(Guid uid, string fullName, DateOnly birthday);
    }
}
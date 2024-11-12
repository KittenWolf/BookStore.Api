using BookStore.Core.Models;

namespace BookStore.Core.Abstractions
{
    public interface IBooksRepository
    {
        Task<Guid> Create(Guid uid, string title, uint publishedYear, Book.GenreType genre, Guid authorUid);
        Task<Guid> Delete(Guid uid);
        Task<List<Book>> GetAll();
        Task<Book?> GetByUid(Guid uid);
        Task<Guid> Update(Guid uid, string title, uint publishedYear, Book.GenreType genre, Guid authorUid);
    }
}
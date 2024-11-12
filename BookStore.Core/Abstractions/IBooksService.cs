using BookStore.Core.Models;

namespace BookStore.Core.Abstractions
{
    public interface IBooksService
    {
        Task<Guid> CreateBook(Book book);
        Task<Guid> DeleteBook(Guid uid);
        Task<List<Book>> GetAllBooks();
        Task<Book?> GetBookByUid(Guid uid);
        Task<Guid> UpdateBook(Guid uid, string title, uint publishedYear, Book.GenreType genre, Guid authorUid);
    }
}
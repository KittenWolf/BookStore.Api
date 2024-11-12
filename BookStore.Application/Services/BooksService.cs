using BookStore.Core.Abstractions;
using BookStore.Core.Models;

namespace BookStore.Application.Services
{
    public class BooksService(IBooksRepository bookRepository) : IBooksService
    {
        private readonly IBooksRepository _bookRepository = bookRepository;

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAll();
        }

        public async Task<Book?> GetBookByUid(Guid uid)
        {
            return await _bookRepository.GetByUid(uid);
        }

        public async Task<Guid> CreateBook(Book book)
        {
            return await _bookRepository.Create(book.Uid, book.Title, book.PublishedYear, book.Genre, book.AuthorUid);
        }

        public async Task<Guid> UpdateBook(Guid uid, string title, uint publishedYear, Book.GenreType genre, Guid authorUid)
        {
            return await _bookRepository.Update(uid, title, publishedYear, genre, authorUid);
        }

        public async Task<Guid> DeleteBook(Guid uid)
        {
            return await _bookRepository.Delete(uid);
        }
    }
}

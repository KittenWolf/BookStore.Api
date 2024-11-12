using BookStore.Core.Models;

namespace BookStore.API.Requests
{
    public record BooksRequest(
        string Title,
        uint PublishedYear,
        Book.GenreType Genre,
        Guid AuthorUid);
}

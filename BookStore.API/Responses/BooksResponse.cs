using BookStore.Core.Models;

namespace BookStore.API.Responses
{
    public record BooksResponse(
        string Title,
        Guid Uid,
        uint PublishedYear,
        Book.GenreType Genre,
        Guid AuthorUid);
}

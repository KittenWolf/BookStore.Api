namespace BookStore.API.Responses
{
    public record AuthorsResponse(
        Guid Uid,
        string FullName,
        DateOnly Birthday);
}

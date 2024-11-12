namespace BookStore.API.Requests
{
    public record AuthorsRequest(
        string FullName,
        DateOnly Birthday);
}

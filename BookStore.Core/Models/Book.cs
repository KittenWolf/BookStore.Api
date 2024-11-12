namespace BookStore.Core.Models
{
    public class Book
    {
        public const int MAX_TITLE_LENGTH = 150;

        public enum GenreType
        {
            Adventure,
            Detective,
            Fantasy
        }

        private Book(Guid uid, string title, uint publishedYear, GenreType genre, Guid authorUid)
        {
            Uid = uid;
            Title = title;
            PublishedYear = publishedYear;
            Genre = genre;
            AuthorUid = authorUid;
        }

        public Guid Uid { get; }
        public string Title { get; } = string.Empty;
        public uint PublishedYear { get; }
        public GenreType Genre { get; }
        public Guid AuthorUid { get; }

        public static (Book Book, string Error) Create(Guid uid, string title, uint publishedYear, GenreType genre, Guid authorUid)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(title))
            {
                error = "Title is empty";
            }

            if (title.Length > MAX_TITLE_LENGTH)
            {
                error = "Title is too long";
            }

            var book = new Book(uid, title, publishedYear, genre, authorUid);

            return (book, error);
        }
    }
}

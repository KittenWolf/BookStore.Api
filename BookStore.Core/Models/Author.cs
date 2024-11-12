namespace BookStore.Core.Models
{
    public class Author
    {
        public const int MAX_FULLNAME_LENGTH = 100;

        private Author(Guid uid, string fullName, DateOnly birthday)
        {
            Uid = uid;
            FullName = fullName;
            Birthday = birthday;
        }

        public Guid Uid { get; }
        public string FullName { get; } = string.Empty;
        public DateOnly Birthday { get; }

        public static (Author Author, string Error) Create(Guid uid, string fullName, DateOnly birthday)
        {
            var error = string.Empty;

            if (string.IsNullOrEmpty(fullName))
            {
                error = "Full name is empty";
            }

            var author = new Author(uid, fullName, birthday);

            return (author, error);
        }
    }
}

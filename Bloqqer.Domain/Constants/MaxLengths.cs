namespace Bloqqer.Domain.Constants;

public static class MaxLengths
{
    public static class ApplicationUser
    {
        public const int FirstName = 256;
        public const int MiddleName = 256;
        public const int LastName = 256;
    }

    public static class Bloq
    {
        public const int Title = 256;
        public const int Description = 256;
    }

    public static class Comment
    {
        public const int Content = 256;
    }

    public static class Post
    {
        public const int Title = 256;
        public const int Description = 256;
        public const int Content = 256;
    }
}
namespace Buntu.Infrastructure.Constants
{
    public static class ValidationConstants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 100;

        public const int EmailMinLength = 10;
        public const int EmailMaxLength = 60;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 20;

        public const int ContentMinLength = 2;
        public const int ContentMaxLength = 1000;

        public const int MaxPostsPerPage = 15;
    }
}

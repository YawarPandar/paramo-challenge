namespace Sat.Recruitment.Abstractions.Helpers
{
    public interface IConstants
    {
        public const string DUPLICATED_USER = "User is duplicated";
        public const string USER_CREATED = "User Created";
        public const string INVALID_USER_TYPE = "Invalid user type";
        public const string INVALID_EMAIL = "Invalid email";
        public const string INVALID_DATA_SOURCE = "Invalid data source";
        public enum UserType
        {
            Normal,
            SuperUser,
            Premium
        }
    }
}

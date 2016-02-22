namespace RealEstates.Common.Constants
{
    public class RealEstateConstants
    {
        public const int DefaultRealEstateTake = 10;
        public const int DefaultRealEstateSkip = 0;

        public const int TitleMinLength = 5;
        public const int TitleMaxLength = 50;

        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 1000;

        public const int MinConstructionYear = 1800;

        // Comment
        public const int CommentTextMinLenght = 5;
        public const int CommentTextMaxLenght = 2500;

        public const string EmailRegEx = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
        @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
    }
}
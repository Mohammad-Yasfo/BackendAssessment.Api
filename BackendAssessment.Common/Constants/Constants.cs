namespace BackendAssessment.Common.Constants
{
    public class Constants
    {
        public const string EmailTemplateReplacementExpression = @"\{{(.+?)\}}";

        public const string ApplicationDateFormat = "dd/MM/yyyy";
        public const string ApplicationDateTimeFrFormat = "dd/MM/yyyy HH:mm:ss";
        public const string ApplicationDateTimeEnFormat = "MM/dd/yyyy HH:mm:ss";
        public const string ApplicationTimeFormat = "HH:mm:ss";

        public const string MicroserviceDateFormat = "MM/dd/yyyy";
        public const string MicroserviceDateTimeFormat = "yyyy-MM-ddTHH:mm:ss";

        public const string TargetAddressForEmailPingService = "no-reply@wingsphere.com";

        public const int TitleMinLength = 2;
        public const int TinyTitleMaxLength = 10;
        public const int ShortTitleMaxLength = 25;
        public const int MediumTitleMaxLength = 50;
        public const int LongTitleMaxLength = 100;
        public const int NotesMinLength = 1;
        public const int NotesMaxLength = 250;
        public const int DescriptionMinLength = 10;
        public const int DescriptionMaxLength = 300;
    }
}
using BackendAssessment.Domain.Enums;

namespace BackendAssessment.Common.Extensions
{
    public static class MediaTypeExtension
    {
        public static FileType ToMediaType(this String contentType)
        {
            return (object)contentType.ToLower() switch
            {
                "video/3gpp2" => FileType.Video,
                "video/3gpp" => FileType.Video,
                "text/xml" => FileType.File,
                "text/plain" => FileType.File,
                "text/csv" => FileType.File,
                "video/x-ms-asf" => FileType.Video,
                "video/x-msvideo" => FileType.Video,
                "video/mpeg" => FileType.Video,
                "video/x-ivf" => FileType.Video,
                "video/x-flv" => FileType.Video,
                "video/quicktime" => FileType.Video,
                "video/mp4" => FileType.Video,
                "video/x-ms-wmp" => FileType.Video,
                "video/x-ms-wmv" => FileType.Video,
                "video/x-ms-wmx" => FileType.Video,
                "image/bmp" => FileType.Photo,
                "image/gif" => FileType.Photo,
                "image/pjpeg" => FileType.Photo,
                "image/x-icon" => FileType.Photo,
                "image/jpeg" => FileType.Photo,
                "image/pict" => FileType.Photo,
                "image/png" => FileType.Photo,
                "image/x-portable-anymap" => FileType.Photo,
                "image/x-macpaint" => FileType.Photo,
                "image/x-quicktime" => FileType.Photo,
                "image/x-rgb" => FileType.Photo,
                "image/tiff" => FileType.Photo,
                "image/vnd.wap.wbmp" => FileType.Photo,
                "image/vnd.ms-photo" => FileType.Photo,
                "image/x-xpixmap" => FileType.Photo,
                _ => FileType.File,
            };
        }
    }
}
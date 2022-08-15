using BackendAssessment.Application.Storage.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BackendAssessment.Api.Base
{
    public class BaseApiController : ControllerBase
    {
        protected readonly ILogger _logger;

        #region Constructor

        public BaseApiController(ILogger logger)
        {
            _logger = logger;
        }

        #endregion

        bool isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development";

        protected string GetHotelFileUrl(Guid hotelId, Guid id) => Url.ActionLink(action: "FileAsync", controller: "HotelProfile", values: new { hotelId, id });

        protected FileStreamResult CreateFileResult(AttachmentContentDto attachment)
        {
            return File(new System.IO.MemoryStream(attachment.Content), attachment.Attachment.ContentType, attachment.Attachment.Name);
        }

        //TODO: Handel system errors
    }
}
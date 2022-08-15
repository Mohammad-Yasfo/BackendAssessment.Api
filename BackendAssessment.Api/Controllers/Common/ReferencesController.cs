using BackendAssessment.Api.Base;
using Microsoft.AspNetCore.Mvc;

namespace BackendAssessment.Api.Controllers.Common
{
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ReferencesController : BaseApiController
    {
        private readonly IHotelReferencesService service;

        public ReferencesController(
            IHotelReferencesService service,
            ILogger<ReferencesController> logger
            ) : base(logger)
        {
            this.service = service;

        }

        [HttpGet("facilities")]
        [Produces(typeof(HotelFacilitiesDto))]
        public async Task<ActionResult<HotelFacilitiesDto>> GetSpaceLayouts([FromQuery] Guid? hotelId)
        {
            if (hotelId.HasValue)
                return await service.GetAllAsync(hotelId.Value);

            return await service.GetAllAsync();
        }
    }
}
using BackendAssessment.Api.Base;
using BackendAssessment.Application.Hotels.Contracts;
using BackendAssessment.Application.Hotels.Dtos;
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
        public async Task<ActionResult<HotelFacilitiesDto>> GetAsync([FromQuery] Guid? hotelId)
        {
            if (hotelId.HasValue)
                return await service.GetAllAsync(hotelId.Value);

            return await service.GetAllAsync();
        }
    }
}
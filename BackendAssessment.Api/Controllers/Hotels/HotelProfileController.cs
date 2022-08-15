using BackendAssessment.Api.Base;
using BackendAssessment.Application.Common.Dtos;
using BackendAssessment.Application.Hotels.Contracts;
using BackendAssessment.Application.Hotels.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAssessment.Api.Controllers.Hotels
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1.0/hotels")]
    //[Authorize]
    [ApiController]
    public class HotelProfileController : BaseApiController
    {
        private readonly IHotelsService service;
        private readonly AbstractValidator<PagingDto> pagingValidator;

        public HotelProfileController(IHotelsService service,
            AbstractValidator<PagingDto> pagingValidator,
            ILogger<HotelProfileController> logger) : base(logger)
        {
            this.service = service;
            this.pagingValidator = pagingValidator;
        }

        [HttpGet]
        [Produces(typeof(IList<HotelListingItemDto>))]
        public async Task<IActionResult> GetAsync([FromQuery] string hotelName)
        {
            try
            {
                var result = await service.GetAsync(hotelName);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("profile/{id}")]
        [Produces(typeof(IList<HotelListingItemDto>))]
        public async Task<IActionResult> GetAsync([FromQuery] Guid hotelId)
        {
            try
            {
                var result = await service.GetProfileAsync(hotelId);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
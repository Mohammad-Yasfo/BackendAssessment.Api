using BackendAssessment.Api.Base;
using BackendAssessment.Application.Common.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackendAssessment.Api.Controllers.Hotels
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1.0/hotels/profile")]
    //[Authorize]
    [ApiController]
    public class HotelProfileController : BaseApiController
    {
        private readonly IHotelProfilesService service;
        private readonly AbstractValidator<PagingDto> pagingValidator;

        public HotelProfileController(IHotelProfilesService service,
            AbstractValidator<PagingDto> pagingValidator,
            ILogger<HotelProfileController> logger) : base(logger)
        {
            this.service = service;
            this.pagingValidator = pagingValidator;
        }
        
        [HttpGet("{id}")]
        [Produces(typeof(PaginatedDto<IntermediariesBookingListItemDto>))]
        public async Task<IActionResult> GetRequestsAsync([FromQuery] PagingDto pagingDto)
        {
            try
            {
                var validationResult = pagingValidator.Validate(pagingDto);

                if (!validationResult.IsValid)
                {
                    var modelState = validationResult.ToModelState(ModelState);
                    return BadRequest(modelState);
                }

                var result = await service.GetRequestsAsync(pagingDto.PageIndex, pagingDto.PageSize);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
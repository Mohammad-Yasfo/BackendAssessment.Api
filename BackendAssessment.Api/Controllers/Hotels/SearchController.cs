using BackendAssessment.Api.Base;
using BackendAssessment.Api.Extensions;
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
    [Route("api/v1.0/attachments")]
    //[Authorize]
    [ApiController]
    public class SearchController : BaseApiController
    {
        private readonly ISearchService service;
        private readonly AbstractValidator<PagingDto> pagingValidator;

        public SearchController(ISearchService service,
            AbstractValidator<PagingDto> pagingValidator,
            ILogger<SearchController> logger) : base(logger)
        {
            this.service = service;
            this.pagingValidator = pagingValidator;
        }

        [HttpGet]
        [Produces(typeof(PaginatedDto<HotelListingItemDto>))]
        public async Task<IActionResult> GetRequestsAsync([FromQuery] PagingDto pagingDto,
            [FromForm] string searchName, [FromForm] string checkIn, [FromForm] string checkOut, [FromForm] FilterDto filterDto)
        {
            //Validation
            var validationResult = pagingValidator.Validate(pagingDto);

            if (!validationResult.IsValid)
            {
                var modelState = validationResult.ToModelState(ModelState);
                return BadRequest(modelState);
            }

            try
            {
                var result = await service.GetAsync(pagingDto.PageIndex, pagingDto.PageSize, searchName, checkIn, checkOut, filterDto);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
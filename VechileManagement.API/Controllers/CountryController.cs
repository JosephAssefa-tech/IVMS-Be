using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.Countries.Requests.Command;
using VechileManagement.Application.Features.Countries.Requests.Request;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.API.Controllers
{
    [Route("")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpPost("country", Name = ApiActions.CreateCountry)]
        public async Task<ActionResult<CreateCountryResponse>> CreateCountry([FromBody] CreateCountryDto countryDto)
        {
            var command = new CreateCountryCommand { CreateCountryDto = countryDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/country/{result.Data}", UriKind.Relative),
                result.Data);
        }
        [HttpGet("country", Name = ApiActions.GetCountries)]
        public async Task<ActionResult<GetCountriesResponse>> GetCountries()
        {
            var results = await _mediator.Send(new GetCountriesRequest());
            return Ok(results);
        }
        [HttpPut("country", Name = ApiActions.UpdateCountry)]
        public async Task<ActionResult<UpdateCountryResponse>> UpdateCountry([FromBody] UpdateCountryDto updateDto)
        {
            var command = new UpdateCountryCommand { UpdateCountryDto = updateDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/country/{updateDto.Id}", UriKind.Relative),
                result.Data);
        }
        [HttpDelete("country/{id}", Name = ApiActions.DeleteCountry)]
        public async Task<ActionResult<DeleteCountryResponse>> DeleteCountryResponse(Guid id)
        {
            var command = new DeleteCountryCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Ok(result);
        }

    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.Countries.Requests.Command;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.Factories.DTOs;
using VechileManagement.Application.Features.Factories.Requests;
using VechileManagement.Application.Features.Factories.Requests.Command;
using VechileManagement.Application.Features.Factories.Responses;
using VechileManagement.Application.Features.Inflations.DTOs;
using VechileManagement.Application.Features.Inflations.Requests.Command;
using VechileManagement.Application.Features.Inflations.Requests.Request;
using VechileManagement.Application.Features.Inflations.Responses;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.API.Controllers
{
    [Route("")]
    [ApiController]
    public class InflationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InflationController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet("inflation", Name = ApiActions.GetInflations)]
        public async Task<ActionResult<GetInflationsResponse>> GetInflations()
        {
            var results = await _mediator.Send(new GetInflationsRequest());
            return Ok(results);
        }

        [HttpPost("inflation", Name = ApiActions.CreateInflation)]
        public async Task<ActionResult<CreateInflationResponse>> CreateInflation([FromBody] CreateInflationDto InflationDto)
        {
            var command = new CreateInflationCommand { CreateInflationDto = InflationDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/inflation/{result.Data}", UriKind.Relative),
                result.Data);
        }
        [HttpPut("inflation", Name = ApiActions.UpdateInflation)]
        public async Task<ActionResult<UpdateInflationResponse>> UpdateInflation([FromBody] UpdateInflationDto updateDto)
        {
            var command = new UpdateInflationCommand { UpdateInflationDto = updateDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/inflation/{updateDto.Id}", UriKind.Relative),
                result.Data);
        }
        [HttpDelete("inflation/{id}", Name = ApiActions.DeleteInflations)]
        public async Task<ActionResult<DeleteInflationResponse>> lkl(Guid id)
        {
            var command = new DeleteInflationCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

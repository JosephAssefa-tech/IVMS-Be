using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.Countries.Requests.Command;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.Depreciations.DTOs;
using VechileManagement.Application.Features.Depreciations.Requests.Command;
using VechileManagement.Application.Features.Depreciations.Requests.Queries;
using VechileManagement.Application.Features.Depreciations.Response;
using VechileManagement.Application.Features.Factories.DTOs;
using VechileManagement.Application.Features.Factories.Requests;
using VechileManagement.Application.Features.Factories.Requests.Command;
using VechileManagement.Application.Features.Factories.Responses;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.API.Controllers
{
    [Route("")]
    [ApiController]
    public class DepreciationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepreciationsController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet("depreciations", Name = ApiActions.GetDepreciations)]
        public async Task<ActionResult<GetDepreciationsResponse>> GetDepreciations()
        {
            var results = await _mediator.Send(new GetDepreciationsRequest());
            return Ok(results);
        }

        [HttpPost("depreciations", Name = ApiActions.CreateDepreciation)]
        public async Task<ActionResult<CreateDepreciationResponse>> CreateDepreciation([FromBody] CreateDeperciationDto deperciationDto)
        {
            var command = new CreateDeperciationCommand { CreateDeperciationDto = deperciationDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/depreciations/{result.Data}", UriKind.Relative),
                result.Data);
        }
        [HttpPut("depreciations", Name = ApiActions.UpdateDepreciation)]
        public async Task<ActionResult<UpdateDepreciationResponse>> UpdateDepreciation([FromBody] UpdateDeperciationDto updateDto)
        {
            var command = new UpdateDeperciationCommand { UpdateDeperciationDto = updateDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/depreciations/{updateDto.Id}", UriKind.Relative),
                result.Data);
        }
        [HttpDelete("depreciations/{id}", Name = ApiActions.DeleteDepreciation)]
        public async Task<ActionResult<DeleteDepreciationResponse>> DeleteDepreciation(Guid id)
        {
            var command = new DeleteaDeperciationCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

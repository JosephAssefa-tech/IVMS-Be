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
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.API.Controllers
{
    [Route("")]
    [ApiController]
    public class FactoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FactoryController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet("factory", Name = ApiActions.GetFactories)]
        public async Task<ActionResult<GetFactoriesResponse>> GetFactories()
        {
            var results = await _mediator.Send(new GetFactoriesRequest());
            return Ok(results);
        }

        [HttpPost("factory", Name = ApiActions.CreateFactory)]
        public async Task<ActionResult<CreateFactoryResponse>> CreateFactory([FromBody] CreateFactoryDto factoryDto)
        {
            var command = new CreateFactoryCommand { CreateFactoryDto = factoryDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/factory/{result.Data}", UriKind.Relative),
                result.Data);
        }
        [HttpPut("factory", Name = ApiActions.UpdateFactory)]
        public async Task<ActionResult<UpdateFactoryResponse>> UpdateFactory([FromBody] UpdateFactoryDto updateDto)
        {
            var command = new UpdateFactoryCommand { UpdateFactoryDto = updateDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/factory/{updateDto.Id}", UriKind.Relative),
                result.Data);
        }
        [HttpDelete("factory/{id}", Name = ApiActions.DeleteFactory)]
        public async Task<ActionResult<DeleteFactoryResponse>> DeleteFactory(Guid id)
        {
            var command = new DeleteFactoryCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

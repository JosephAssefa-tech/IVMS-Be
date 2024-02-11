using MediatR;
using Microsoft.AspNetCore.Mvc;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.DTOs;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.Requests.Command;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.Requests.Request;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.Responses;



namespace VechileManagement.API.Controllers
{
    [Route("")]
    [ApiController]
    public class FactoryServiceTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FactoryServiceTypeController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpGet("FactoryService", Name = ApiActions.GetFactoryServiceType)]
        public async Task<ActionResult<GetFactoryServiceTypesParameterResponse>> GetFactoryServiceTypes()
        {
            var results = await _mediator.Send(new GetFactoryServiceTypeParameterRequest());
            return Ok(results);
        }

        [HttpPost("FactoryService", Name = ApiActions.CreateFactoryServiceType)]
        public async Task<ActionResult<CreateFactoryServiceTypeParametersResponse>> CreateFactoryServiceTypes([FromBody] CreateFactoryServiceTypeParameterDto Dto)
        {
            var command = new CreateFactoryServiceTypeParametersCommand { CreateFactoryServiceTypeParameterDto = Dto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/FactoryService/{result.Data}", UriKind.Relative),
                result.Data);
        }
        [HttpPut("FactoryService", Name = ApiActions.UpdateFactoryServiceType)]
        public async Task<ActionResult<UpdateFactoryServiceTypeParameterResponse>> UpdateFactory([FromBody] UpdateFactoryServiceTypeParameterDto updateDto)
        {
            var command = new UpdateFactoryServiceTypeParameterCommand { UpdateFactoryServiceTypeParameterDto = updateDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/FactoryService/{updateDto.Id}", UriKind.Relative),
                result.Data);
        }
        [HttpDelete("FactoryService/{id}", Name = ApiActions.DeleteFactoryServiceType)]
        public async Task<ActionResult<DeleteFactoryServiceTypeParameterResponse>> DeleteFactory(Guid id)
        {
            var command = new DeleteFactoryServiceTypeParametersCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

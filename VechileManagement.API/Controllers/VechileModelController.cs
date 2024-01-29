using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VechileManagement.API.Controllers
{
    [Route("")]
    [ApiController]
    public class VechileModelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VechileModelController(IMediator mediator)
        {
            _mediator = mediator;

        }
        [HttpPost("vechile", Name = ApiActions.CreateVechileModel)]
        public async Task<ActionResult<CreateVechileModelResponse>> CreateVechileModel([FromBody] CreateVechileModelDto vechileDto)
        {
            var command = new CreateVechileModelCommand { CreateVechileModelDto = vechileDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/vechile/{result.Data}", UriKind.Relative),
                result.Data);
        }


        [HttpGet("vechile", Name = ApiActions.GetVechileModels)]
        public async Task<ActionResult<GetVechilesModelResponse>> GetVechileModels()
        {
            var results = await _mediator.Send(new GetVechileModelsRequest());
            return Ok(results);
        }

        [HttpPut("vechile", Name = ApiActions.UpdateVechileModels)]
        public async Task<ActionResult<UpdateVechileModelResponse>> UpdateVechileModel([FromBody] UpdateVechileModelDto updateDto)
        {
            var command = new UpdateVechileModelCommand { UpdateVechileModelDto = updateDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/vechile/{updateDto.Id}", UriKind.Relative),
                result.Data);
        }
        [HttpDelete("vechile/{id}", Name = ApiActions.DeleteVechileModels)]
        public async Task<ActionResult<UpdateVechileModelResponse>> DeleteVechileModels(Guid id)
        {
            var command = new DeleteVechileModelCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

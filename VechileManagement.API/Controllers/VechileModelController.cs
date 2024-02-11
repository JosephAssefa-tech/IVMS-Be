using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VechileManagement.Domain.Enums;
using Azure;

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

        [HttpGet("vechileFilter", Name = ApiActions.GetVechileModel)]
        public async Task<ActionResult<GetVechileModelResponse>> GetVechileModel(
     string model,
     Guid factoryId,
     FuelType fuelType,
     [FromQuery] DateTime? From,
     [FromQuery] DateTime? To)
        {
            var request = new GetVechileModelRequest
            {
                Model = model,
                FactoryId = factoryId,
                FuelType = fuelType,
                From = From,
                To = To
            };

            var results = await _mediator.Send(request);
            return Ok(results);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadExcelData(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File is empty");
            }

            try
            {
                await _mediator.Send(new UploadExcelDataCommand { File = file });
                return Ok("File uploaded successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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
        public async Task<ActionResult<DeleteVechileModelResponse>> DeleteVechileModels(Guid id)
        {
            var command = new DeleteVechileModelCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

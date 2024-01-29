using VechileManagement.Application.Features.Customers.DTOs;
using VechileManagement.Application.Features.Customers.Requests;
using VechileManagement.Application.Features.Customers.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace VechileManagement.API.Controllers
{
    [Route("")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("customers", Name = ApiActions.GetCustomers)]
        public async Task<ActionResult<GetCustomersResponse>> GetCustomers()
        {
            var results = await _mediator.Send(new GetCustomersRequest());
            return Ok(results);
        }

        [HttpGet("customer/{id}", Name = ApiActions.GetCustomer)]
        [ProducesResponseType(typeof(CustomerDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetCustomerResponse>> GetCustomer(Guid id)
        {
            var result = await _mediator.Send(new GetCustomerRequest { Id = id});
            if (result.Data == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost("customer", Name = ApiActions.CreateCustomer)]
        public async Task<ActionResult<CreateCustomerResponse>> CreateCustomer([FromBody] CreateCustomerDTO customerDto)
        {
            var command = new CreateCustomerCommand { CreateCustomerDTO = customerDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Created(new Uri($"/customer/{result.Data.Id}", UriKind.Relative), 
                result.Data);
        }

        [HttpPut("customer", Name = ApiActions.UpdateCustomer)]
        public async Task<ActionResult<UpdateCustomerResponse>> UpdateCustomer([FromBody] UpdateCustomerDTO customerDto)
        {
            var command = new UpdateCustomerCommand { UpdateCustomerDTO = customerDto };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete("customer/{id}", Name = ApiActions.DeleteCustomer)]
        public async Task<ActionResult<UpdateCustomerResponse>> DeleteCustomer(Guid id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            var result = await _mediator.Send(command);

            if (result.Errors != null && result.Errors.Count() > 0)
                return BadRequest(result);
            return Ok(result);
        }
    }
}

using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VechileManagement.Application.Features.Factories.Requests;
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
    }
}

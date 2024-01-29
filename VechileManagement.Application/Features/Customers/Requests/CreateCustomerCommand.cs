using VechileManagement.Application.Features.Customers.DTOs;
using VechileManagement.Application.Features.Customers.Responses;
using MediatR;


namespace VechileManagement.Application.Features.Customers.Requests
{
    public class CreateCustomerCommand : IRequest<CreateCustomerResponse>
    {
        public CreateCustomerDTO CreateCustomerDTO { get; set; }
    }
}

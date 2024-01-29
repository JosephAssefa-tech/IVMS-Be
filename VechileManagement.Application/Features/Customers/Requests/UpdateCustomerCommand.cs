using VechileManagement.Application.Features.Customers.DTOs;
using VechileManagement.Application.Features.Customers.Responses;
using MediatR;

namespace VechileManagement.Application.Features.Customers.Requests
{
    public class UpdateCustomerCommand : IRequest<UpdateCustomerResponse>
    {
        public UpdateCustomerDTO UpdateCustomerDTO { get; set; }
    }
}

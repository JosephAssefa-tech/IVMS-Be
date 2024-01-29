using VechileManagement.Application.Features.Customers.Responses;
using MediatR;
using System;

namespace VechileManagement.Application.Features.Customers.Requests
{
    public class DeleteCustomerCommand : IRequest<DeleteCustomerResponse>
    {
        public Guid Id { get; set; }
    }
}

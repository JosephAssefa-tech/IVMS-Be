using VechileManagement.Application.Features.Customers.Responses;
using MediatR;
using System;


namespace VechileManagement.Application.Features.Customers.Requests
{
    public class GetCustomerRequest : IRequest<GetCustomerResponse>
    {
        public Guid Id { get; set; }
    }
}

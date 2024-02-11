using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.Customers.Responses;

namespace VechileManagement.Application.Features.Countries.Requests.Command
{
    public class DeleteCountryCommand : IRequest<DeleteCountryResponse>
    {
        public Guid Id { get; set; }
    }
}

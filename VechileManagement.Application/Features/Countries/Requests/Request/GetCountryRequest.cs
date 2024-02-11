using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Countries.Response;

namespace VechileManagement.Application.Features.Countries.Requests.Request
{
    public class GetCountryRequest : IRequest<GetCountryResponse>
    {
        public Guid Id { get; set; }
    }
}

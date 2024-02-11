using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Factories.Responses;
using VechileManagement.Application.Features.Inflations.Responses;

namespace VechileManagement.Application.Features.Inflations.Requests.Request
{
    public class GetInflationsRequest : IRequest<GetInflationsResponse>
    {
    }
}

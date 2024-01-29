using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Factories.Responses;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.Factories.Requests
{
    public class GetFactoriesRequest : IRequest<GetFactoriesResponse>
    {
    }
}

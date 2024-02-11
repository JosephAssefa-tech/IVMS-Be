using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.Responses;
using VechileManagement.Application.Features.Inflations.Responses;

namespace VechileManagement.Application.Features.FactoryServiceTypeParameters.Requests.Request
{
    public class GetFactoryServiceTypeParameterRequest : IRequest<GetFactoryServiceTypesParameterResponse>
    {
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.DTOs;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.Responses;
using VechileManagement.Application.Features.Inflations.DTOs;
using VechileManagement.Application.Features.Inflations.Responses;

namespace VechileManagement.Application.Features.FactoryServiceTypeParameters.Requests.Command
{
    public class UpdateFactoryServiceTypeParameterCommand : IRequest<UpdateFactoryServiceTypeParameterResponse>
    {
        public UpdateFactoryServiceTypeParameterDto UpdateFactoryServiceTypeParameterDto { get; set; }
    }
}

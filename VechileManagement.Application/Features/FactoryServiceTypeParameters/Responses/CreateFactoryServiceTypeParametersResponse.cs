using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.DTOs;
using VechileManagement.Application.Features.Inflations.DTOs;

namespace VechileManagement.Application.Features.FactoryServiceTypeParameters.Responses
{
    public class CreateFactoryServiceTypeParametersResponse : BaseResponse
    {
        public CreateFactoryServiceTypeParameterDto Data { get; set; }
    }
}

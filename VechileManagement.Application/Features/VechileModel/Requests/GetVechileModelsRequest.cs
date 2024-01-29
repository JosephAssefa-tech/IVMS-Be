using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.VechileModel.Requests
{
    public class GetVechileModelsRequest : IRequest<GetVechilesModelResponse>
    {
    }
}

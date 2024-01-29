using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.VechileModel.Requests
{
    public class UpdateVechileModelCommand : IRequest<UpdateVechileModelResponse>
    {
        public UpdateVechileModelDto UpdateVechileModelDto { get; set; }
    }
}

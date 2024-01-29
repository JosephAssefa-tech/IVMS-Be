using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Application.Features.VechileModel.Requests
{
    public class CreateVechileModelCommand: IRequest<CreateVechileModelResponse>
    {
        public CreateVechileModelDto CreateVechileModelDto { get; set; }

    }
}

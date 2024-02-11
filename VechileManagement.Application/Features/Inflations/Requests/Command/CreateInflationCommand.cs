﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Inflations.DTOs;
using VechileManagement.Application.Features.Inflations.Responses;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.Inflations.Requests.Command
{
    public class CreateInflationCommand : IRequest<CreateInflationResponse>
    {
        public CreateInflationDto CreateInflationDto { get; set; }
    }
}

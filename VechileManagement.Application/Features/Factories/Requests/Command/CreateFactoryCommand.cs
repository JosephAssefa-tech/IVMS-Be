﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Factories.DTOs;
using VechileManagement.Application.Features.Factories.Responses;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.Factories.Requests.Command
{
    public class CreateFactoryCommand : IRequest<CreateFactoryResponse>
    {
        public CreateFactoryDto CreateFactoryDto { get; set; }
    }
}

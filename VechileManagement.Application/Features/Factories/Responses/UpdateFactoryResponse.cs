﻿using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Factories.DTOs;
using VechileManagement.Application.Features.VechileModel.DTOs;

namespace VechileManagement.Application.Features.Factories.Responses
{
    public class UpdateFactoryResponse : BaseResponse
    {
        public UpdateFactoryDto Data { get; set; }
    }
}

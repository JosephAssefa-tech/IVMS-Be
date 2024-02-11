using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Factories.DTOs;

namespace VechileManagement.Application.Features.Factories.Responses
{
    public class CreateFactoryResponse : BaseResponse
    {
        public CreateFactoryDto Data { get; set; }

    }
}

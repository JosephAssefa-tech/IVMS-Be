using VechileManagement.Application.Common;
using VechileManagement.Application.Features.VechileModel.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Application.Features.VechileModel.Responses
{
    public class CreateVechileModelResponse: BaseResponse
    {
        public CreateVechileModelDto Data { get; set; }
    }
}

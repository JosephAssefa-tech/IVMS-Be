using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Inflations.DTOs;
using VechileManagement.Application.Features.VechileModel.DTOs;

namespace VechileManagement.Application.Features.Inflations.Responses
{
    public class GetInflationsResponse : BaseResponse
    {
        public List<ListInflationDto> Data { get; set; }
    }
}

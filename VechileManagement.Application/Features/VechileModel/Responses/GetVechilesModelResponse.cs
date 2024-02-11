using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;
using VechileManagement.Application.Features.VechileModel.DTOs;

namespace VechileManagement.Application.Features.VechileModel.Responses
{
    public class GetVechilesModelResponse : BaseResponse
    {
        public List<ListGetCountriesDto> Data { get; set; }
    }
}

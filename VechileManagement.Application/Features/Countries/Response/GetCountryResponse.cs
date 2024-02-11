using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Countries.DTOs;

namespace VechileManagement.Application.Features.Countries.Response
{
    public class GetCountryResponse : BaseResponse
    {
        public CountryDto Data { get; set; }
    }
}

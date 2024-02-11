using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.VechileModel.DTOs;

namespace VechileManagement.Application.Features.Countries.Response
{
    public class GetCountriesResponse : BaseResponse
    {
        public List<ListCountryDto> Data { get; set; }
    }
}

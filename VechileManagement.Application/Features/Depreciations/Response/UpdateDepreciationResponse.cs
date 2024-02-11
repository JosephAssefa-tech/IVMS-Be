using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.Depreciations.DTOs;

namespace VechileManagement.Application.Features.Depreciations.Response
{
    public class UpdateDepreciationResponse : BaseResponse
    {
        public UpdateDeperciationDto Data { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;

namespace VechileManagement.Application.Features.VechileModel.Responses
{
    public class UploadExcelDataResponse : BaseResponse
    {
    
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

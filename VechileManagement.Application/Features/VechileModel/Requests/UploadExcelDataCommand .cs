using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.VechileModel.Requests
{
    public class UploadExcelDataCommand : IRequest<UploadExcelDataResponse>
    {
        public IFormFile File { get; set; }
    }
}

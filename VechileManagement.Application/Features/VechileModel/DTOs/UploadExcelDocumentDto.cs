using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Application.Features.VechileModel.DTOs
{
    public class UploadExcelDocumentDto
    {
        public IFormFile DocumentFile { get; set; }
    }
}

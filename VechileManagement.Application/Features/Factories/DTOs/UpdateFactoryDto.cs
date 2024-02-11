using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;

namespace VechileManagement.Application.Features.Factories.DTOs
{
    public class UpdateFactoryDto :BaseDTO
    {
        public string FactoryNameAmh { get; set; }
        public string FactoryNameEng { get; set; }
        public decimal Code { get; set; }
    }
}

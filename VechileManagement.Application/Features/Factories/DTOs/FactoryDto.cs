using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Application.Features.Factories.DTOs
{
    public class FactoryDto
    {
        public string FactoryNameAmh { get; set; }
        public string FactoryNameEng { get; }
        public decimal Code { get; set; }
    }
}

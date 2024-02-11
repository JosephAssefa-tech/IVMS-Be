using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Application.Features.Factories.DTOs
{
    public class CreateFactoryDto
    {
        public string FactoryNameAmh { get; set; }
        public string FactoryNameEng { get; set; }
        public decimal Code { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;

namespace VechileManagement.Application.Features.Inflations.DTOs
{
    public class ListInflationDto : BaseDTO
    {
        public int ServiceYear { get; set; }
        public decimal Point { get; set; }
    }
}

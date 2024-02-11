using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Application.Features.Countries.DTOs
{
    public class ListCountryDto
    {
        public int CountryCode { get; set; }
        public decimal Point { get; set; }
        public string CountryNameAmh { get; set; }
        public string CountryNameEng { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Domain.Common;

namespace VechileManagement.Domain.Entities
{
    public class Country : BaseAuditableEntity
    {

        public int CountryCode { get; set; }
        public decimal Point { get; set; }
        public string CountryNameAmh { get; set; }
        public string CountryNameEng { get; set; }

    }
}

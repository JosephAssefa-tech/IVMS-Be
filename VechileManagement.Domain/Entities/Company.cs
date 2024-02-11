using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Domain.Common;

namespace VechileManagement.Domain.Entities
{
    public class Company : BaseAuditableEntity
    {
        public string ManufacturerNameAmh { get; set; }
        public string ManufacturerNameEng { get; set; }
        public decimal Code { get; set; }

    }
}

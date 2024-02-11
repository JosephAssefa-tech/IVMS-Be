using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Domain.Common;

namespace VechileManagement.Domain.Entities
{
    public class Depreciation : BaseAuditableEntity
    {
 
        public Guid VehicleServiceTypeId { get; set; }
        public int ServiceYear { get; set; }
        public int Point { get; set; }


    }
}

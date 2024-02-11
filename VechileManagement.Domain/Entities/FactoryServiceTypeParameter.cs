using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Domain.Common;

namespace VechileManagement.Domain.Entities
{
    public class FactoryServiceTypeParameter : BaseAuditableEntity
    {
        public Guid FactoryId { get; set; }
        public Guid VehicleServiceTypeId { get; set; }
        public int Point { get; set; }
    }
}

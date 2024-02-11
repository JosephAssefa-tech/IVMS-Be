using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Domain.Common;

namespace VechileManagement.Domain.Entities
{
    public class CompanyVechileServiceType : BaseAuditableEntity
    {

       public Guid  VehicleServiceTypeId{get;set;}
        public Guid CompanyId { get;set;}
    }
}

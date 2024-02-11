using System.Collections.Generic;
using VechileManagement.Domain.Common;

namespace VechileManagement.Domain.Entities
{
    public class VehicleServiceType: BaseAuditableEntity
    {
      //  public int VehicleServiceTypeId { get; set; }
        public int Code { get; set; }

        public string DescriptionAmh { get; set; }

        public string DescriptionEng { get; set; }
       
        public float Point { get; set; }
      //  public ICollection<PaymentRevenueService> PaymentRevenueServices { get; set; }
    }
}

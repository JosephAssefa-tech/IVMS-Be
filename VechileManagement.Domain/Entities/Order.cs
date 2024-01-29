using VechileManagement.Domain.Common;
using System;

namespace VechileManagement.Domain.Entities
{
    public class Order : BaseAuditableEntity
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public Guid CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}

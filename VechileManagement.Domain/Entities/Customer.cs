using VechileManagement.Domain.Common;
using VechileManagement.Domain.Enums;
using VechileManagement.Domain.ValueObjects;
using System.Collections.Generic;


namespace VechileManagement.Domain.Entities
{
    public class Customer : BaseAuditableEntity
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public CustomerType CustomerType { get; set; }
        public decimal? CreditLimit { get; set; }
        public virtual IList<Order> Orders { get; set; }
    }
}

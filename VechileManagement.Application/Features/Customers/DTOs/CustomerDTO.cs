using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Orders.DTOs;
using VechileManagement.Domain.Enums;
using VechileManagement.Domain.ValueObjects;
using System.Collections.Generic;

namespace VechileManagement.Application.Features.Customers.DTOs
{
    public class CustomerDTO : BaseDTO
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public CustomerType CustomerType { get; set; }
        public decimal? CreditLimit { get; set; }
        public virtual IList<ListOrderDTO> Orders { get; set; }
    }
}

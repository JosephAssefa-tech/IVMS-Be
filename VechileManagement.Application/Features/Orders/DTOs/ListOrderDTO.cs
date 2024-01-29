using System;
using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Customers.DTOs;

namespace VechileManagement.Application.Features.Orders.DTOs
{
    public class ListOrderDTO : BaseDTO
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
        public virtual ListCustomerDTO Customer { get; set; }

    }
}

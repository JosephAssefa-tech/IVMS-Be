using System;


namespace VechileManagement.Application.Features.Orders.DTOs
{
    public class CreateOrderDTO
    {
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int CustomerId { get; set; }
    }
}

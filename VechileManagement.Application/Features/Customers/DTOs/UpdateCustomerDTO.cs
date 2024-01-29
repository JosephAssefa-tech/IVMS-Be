using VechileManagement.Application.Common;
using VechileManagement.Domain.Enums;
using VechileManagement.Domain.ValueObjects;


namespace VechileManagement.Application.Features.Customers.DTOs
{
    public class UpdateCustomerDTO : BaseDTO
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public CustomerType CustomerType { get; set; }
        public decimal? CreditLimit { get; set; }
    }
}

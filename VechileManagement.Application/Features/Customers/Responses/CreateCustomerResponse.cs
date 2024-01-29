using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Customers.DTOs;

namespace VechileManagement.Application.Features.Customers.Responses
{
    public class CreateCustomerResponse : BaseResponse
    {
        public CreateCustomerDTO Data { get; set; }
    }
}

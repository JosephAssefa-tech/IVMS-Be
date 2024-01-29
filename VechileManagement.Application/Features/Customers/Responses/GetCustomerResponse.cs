using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Customers.DTOs;

namespace VechileManagement.Application.Features.Customers.Responses
{
    public class GetCustomerResponse : BaseResponse
    {
        public CustomerDTO Data { get; set; }
    }
}

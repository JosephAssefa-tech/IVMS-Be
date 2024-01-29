using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Customers.DTOs;


namespace VechileManagement.Application.Features.Customers.Responses
{
    public class UpdateCustomerResponse : BaseResponse
    {
        public UpdateCustomerDTO Data { get; set; }
    }
}

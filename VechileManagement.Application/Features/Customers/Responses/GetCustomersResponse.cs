using VechileManagement.Application.Common;
using VechileManagement.Application.Features.Customers.DTOs;
using System.Collections.Generic;


namespace VechileManagement.Application.Features.Customers.Responses
{
    public class GetCustomersResponse : BaseResponse
    {
        public List<ListCustomerDTO> Data { get; set; }
    }
}

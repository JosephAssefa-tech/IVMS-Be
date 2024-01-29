using AutoMapper;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Customers.DTOs;
using VechileManagement.Application.Features.Customers.Requests;
using VechileManagement.Application.Features.Customers.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VechileManagement.Application.Features.Customers.Handlers.Queries
{
    public class GetCustomersRequestHandler : IRequestHandler<GetCustomersRequest, GetCustomersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomersRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetCustomersResponse> Handle(GetCustomersRequest request, 
            CancellationToken cancellationToken)
        {
            var customers = (await _unitOfWork.CustomerRepository.GetAllAsync()).OrderBy(c => c.Created);
            var response = new GetCustomersResponse();
            response.Success = true;
            response.Data = _mapper.Map<List<ListCustomerDTO>>(customers);
            return response;
        }
    }
}

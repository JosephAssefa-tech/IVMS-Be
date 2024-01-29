using AutoMapper;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Customers.DTOs;
using VechileManagement.Application.Features.Customers.Requests;
using VechileManagement.Application.Features.Customers.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace VechileManagement.Application.Features.Customers.Handlers.Queries
{
    public class GetCustomerRequestHandler : IRequestHandler<GetCustomerRequest, GetCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCustomerRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetCustomerResponse> Handle(GetCustomerRequest request, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);
            var response = new GetCustomerResponse();
            if(customer == null)
            {
                response.Success = false;
                response.Message = "Customer Not Found.";
                return response;
            }
            response.Success = true;
            response.Data = _mapper.Map<CustomerDTO>(customer);
            return response;
        }
    }
}

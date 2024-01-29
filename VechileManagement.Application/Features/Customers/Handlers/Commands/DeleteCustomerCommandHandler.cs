using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Customers.Requests;
using VechileManagement.Application.Features.Customers.Responses;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Generic;

namespace VechileManagement.Application.Features.Customers.Handlers.Commands
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, DeleteCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCustomerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteCustomerResponse> Handle(DeleteCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(request.Id);

            var response = new DeleteCustomerResponse();

            if (customer == null)
            {
                response.Success = false;
                response.Message = "Deletion Failed.";
                response.Errors = new List<string> { "Customer Not Found." };
                return response;
            }

            await _unitOfWork.CustomerRepository.DeleteAsync(customer);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Deleted Successfully.";
            
            return response;
        }
    }
}

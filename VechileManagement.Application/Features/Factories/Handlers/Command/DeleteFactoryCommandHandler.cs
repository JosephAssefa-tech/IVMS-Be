using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Factories.Requests.Command;
using VechileManagement.Application.Features.Factories.Responses;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.Factories.Handlers.Command
{
    public class DeleteFactoryCommandHandler : IRequestHandler<DeleteFactoryCommand, DeleteFactoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteFactoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteFactoryResponse> Handle(DeleteFactoryCommand request, CancellationToken cancellationToken)
        {
            var factory = await _unitOfWork.FactoryRepository.GetByIdAsync(request.Id);

            var response = new DeleteFactoryResponse();

            if (factory == null)
            {
                response.Success = false;
                response.Message = "Deletion Failed.";
                response.Errors = new List<string> { "Factory  Not Found." };
                return response;
            }
            await _unitOfWork.FactoryRepository.SoftDeleteAsync(factory);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Deleted Successfully.";

            return response;
        }
    }
}

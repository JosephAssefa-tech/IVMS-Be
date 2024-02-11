using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.Requests.Command;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.Responses;
using VechileManagement.Application.Features.Inflations.Requests.Command;
using VechileManagement.Application.Features.Inflations.Responses;

namespace VechileManagement.Application.Features.FactoryServiceTypeParameters.Handlers.Commands
{
    public class DeleteFactoryServiceTypeParametersCommandHandler : IRequestHandler<DeleteFactoryServiceTypeParametersCommand, DeleteFactoryServiceTypeParameterResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFactoryServiceTypeParametersCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteFactoryServiceTypeParameterResponse> Handle(DeleteFactoryServiceTypeParametersCommand request, CancellationToken cancellationToken)
        {
            var data = await _unitOfWork.FactoryServiceTypeParameterRepository.GetByIdAsync(request.Id);

            var response = new DeleteFactoryServiceTypeParameterResponse();

            if (data == null)
            {
                response.Success = false;
                response.Message = "Deletion Failed.";
                response.Errors = new List<string> { "Vechile Model Not Found." };
                return response;
            }
            await _unitOfWork.FactoryServiceTypeParameterRepository.SoftDeleteAsync(data);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Deleted Successfully.";

            return response;
        }
    }
}

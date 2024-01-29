using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.VechileModel.Handlers.Commands
{
    public class DeleteVechileModelCommandHandler : IRequestHandler<DeleteVechileModelCommand, DeleteVechileModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteVechileModelCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteVechileModelResponse> Handle(DeleteVechileModelCommand request, CancellationToken cancellationToken)
        {
            var vechileModel = await _unitOfWork.VechileModelRepository.GetByIdAsync(request.Id);

            var response = new DeleteVechileModelResponse();

            if (vechileModel == null)
            {
                response.Success = false;
                response.Message = "Deletion Failed.";
                response.Errors = new List<string> { "Vechile Model Not Found." };
                return response;
            }
            await _unitOfWork.VechileModelRepository.SoftDeleteAsync(vechileModel);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Deleted Successfully.";

            return response;
        }
    }
}

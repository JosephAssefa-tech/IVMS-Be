using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Countries.Requests.Command;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.Depreciations.Requests.Command;
using VechileManagement.Application.Features.Depreciations.Response;

namespace VechileManagement.Application.Features.Depreciations.Handlers.Command
{
    public class DeleteDeperciationCommandHandler : IRequestHandler<DeleteaDeperciationCommand, DeleteDepreciationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDeperciationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteDepreciationResponse> Handle(DeleteaDeperciationCommand request, CancellationToken cancellationToken)
        {
            var depreciation = await _unitOfWork.deperciationRepository.GetByIdAsync(request.Id);

            var response = new DeleteDepreciationResponse();

            if (depreciation == null)
            {
                response.Success = false;
                response.Message = "Deletion Failed.";
                response.Errors = new List<string> { "country  Not Found." };
                return response;
            }
            await _unitOfWork.deperciationRepository.SoftDeleteAsync(depreciation);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Deleted Successfully.";

            return response;
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Inflations.Requests.Command;
using VechileManagement.Application.Features.Inflations.Responses;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Features.Inflations.Handlers.Commands
{

    public class DeleteInflationCommandHandler : IRequestHandler<DeleteInflationCommand, DeleteInflationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteInflationCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<DeleteInflationResponse> Handle(DeleteInflationCommand request, CancellationToken cancellationToken)
        {
            var inflation = await _unitOfWork.InflationRepository.GetByIdAsync(request.Id);

            var response = new DeleteInflationResponse();

            if (inflation == null)
            {
                response.Success = false;
                response.Message = "Deletion Failed.";
                response.Errors = new List<string> { "Vechile Model Not Found." };
                return response;
            }
            await _unitOfWork.InflationRepository.SoftDeleteAsync(inflation);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Deleted Successfully.";

            return response;
        }
    }
}

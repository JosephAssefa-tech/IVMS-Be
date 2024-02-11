using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Countries.Requests.Command;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.Countries.Handlers.Command
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, DeleteCountryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCountryCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DeleteCountryResponse> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _unitOfWork.countryRepository.GetByIdAsync(request.Id);

            var response = new DeleteCountryResponse();

            if (country == null)
            {
                response.Success = false;
                response.Message = "Deletion Failed.";
                response.Errors = new List<string> { "country  Not Found." };
                return response;
            }
            await _unitOfWork.countryRepository.SoftDeleteAsync(country);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Deleted Successfully.";

            return response;
        }
    }
}

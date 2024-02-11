using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Depreciations.DTOs;
using VechileManagement.Application.Features.Depreciations.Requests.Command;
using VechileManagement.Application.Features.Depreciations.Response;
using VechileManagement.Application.Features.Depreciations.Validators;
using VechileManagement.Application.Features.Factories.DTOs;
using VechileManagement.Application.Features.Factories.Requests.Command;
using VechileManagement.Application.Features.Factories.Responses;
using VechileManagement.Application.Features.Factories.Validators;

namespace VechileManagement.Application.Features.Depreciations.Handlers.Command
{

    public class UpdateDeperciationCommandHandler : IRequestHandler<UpdateDeperciationCommand, UpdateDepreciationResponse>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateDeperciationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateDepreciationResponse> Handle(UpdateDeperciationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDeperciationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateDeperciationDto);

            var response = new UpdateDepreciationResponse();
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            // Fetch the existing event by eventId
            var existingDepreciation = await _unitOfWork.deperciationRepository.GetByIdAsync(request.UpdateDeperciationDto.Id);

            if (existingDepreciation == null)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = new List<string> { "Factory Not Found." };
                return response;
            }
            existingDepreciation.ServiceYear = request.UpdateDeperciationDto.ServiceYear;

            existingDepreciation.VehicleServiceTypeId = request.UpdateDeperciationDto.VehicleServiceTypeId;

            // Save the updated event
            await _unitOfWork.deperciationRepository.UpdateAsync(existingDepreciation);
            await _unitOfWork.Save();


            response.Success = true;
            response.Message = "Updated Successfully.";
            response.Data = _mapper.Map<UpdateDeperciationDto>(existingDepreciation);

            return response;
        }
    }
}

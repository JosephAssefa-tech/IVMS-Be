using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.DTOs;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.Requests.Command;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.Responses;
using VechileManagement.Application.Features.FactoryServiceTypeParameters.Validators;
using VechileManagement.Application.Features.Inflations.DTOs;
using VechileManagement.Application.Features.Inflations.Requests.Command;
using VechileManagement.Application.Features.Inflations.Responses;
using VechileManagement.Application.Features.Inflations.Validators;

namespace VechileManagement.Application.Features.FactoryServiceTypeParameters.Handlers.Commands
{
    public class UpdateFactoryServiceTypeParametersCommandHandler : IRequestHandler<UpdateFactoryServiceTypeParameterCommand, UpdateFactoryServiceTypeParameterResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateFactoryServiceTypeParametersCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateFactoryServiceTypeParameterResponse> Handle(UpdateFactoryServiceTypeParameterCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFactoryServiceTypeParameterDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateFactoryServiceTypeParameterDto);

            var response = new UpdateFactoryServiceTypeParameterResponse();
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            // Fetch the existing event by eventId
            var existingData = await _unitOfWork.FactoryServiceTypeParameterRepository.GetByIdAsync(request.UpdateFactoryServiceTypeParameterDto.Id);

            if (existingData == null)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = new List<string> { "Inflation Not Found." };
                return response;
            }


            existingData.VehicleServiceTypeId = request.UpdateFactoryServiceTypeParameterDto.VehicleServiceTypeId;
            existingData.Point = request.UpdateFactoryServiceTypeParameterDto.Point;
            existingData.FactoryId = request.UpdateFactoryServiceTypeParameterDto.FactoryId;

            // Save the updated event
            await _unitOfWork.FactoryServiceTypeParameterRepository.UpdateAsync(existingData);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Updated Successfully.";
            response.Data = _mapper.Map<UpdateFactoryServiceTypeParameterDto>(existingData);

            return response;
        }
    }
}

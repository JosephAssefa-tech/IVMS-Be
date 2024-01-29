using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;
using VechileManagement.Application.Features.VechileModel.Validators;

namespace VechileManagement.Application.Features.VechileModel.Handlers.Commands
{
    public class UpdateVechileModelCommandHandler : IRequestHandler<UpdateVechileModelCommand, UpdateVechileModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateVechileModelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateVechileModelResponse> Handle(UpdateVechileModelCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateVechileModelDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateVechileModelDto);

            var response = new UpdateVechileModelResponse();
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            // Fetch the existing event by eventId
            var existingVechileModel = await _unitOfWork.VechileModelRepository.GetByIdAsync(request.UpdateVechileModelDto.Id);

            if (existingVechileModel == null)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = new List<string> { "VechileModel Not Found." };
                return response;
            }

            // Update the properties of the existing event
            existingVechileModel.Model = request.UpdateVechileModelDto.Model;
            existingVechileModel.Width = request.UpdateVechileModelDto.Width;
            existingVechileModel.Height = request.UpdateVechileModelDto.Height;
            existingVechileModel.Length = request.UpdateVechileModelDto.Length;
            existingVechileModel.AxleDistance = request.UpdateVechileModelDto.AxleDistance;
            existingVechileModel.EngineCapacity = request.UpdateVechileModelDto.EngineCapacity;
            existingVechileModel.CargoCapacity = request.UpdateVechileModelDto.CargoCapacity;
            existingVechileModel.FactoryId = request.UpdateVechileModelDto.FactoryId;
            existingVechileModel.NumberOfSeat = request.UpdateVechileModelDto.NumberOfSeat;
            existingVechileModel.NumberOfTyreB = request.UpdateVechileModelDto.NumberOfTyreB;
            existingVechileModel.NumberOfTyreF= request.UpdateVechileModelDto.NumberOfTyreF;
            existingVechileModel.FuelType = request.UpdateVechileModelDto.FuelType;
            existingVechileModel.GrossWeight = request.UpdateVechileModelDto.GrossWeight;
            existingVechileModel.NetWeight = request.UpdateVechileModelDto.NetWeight;
            existingVechileModel.TypeOfDrive = request.UpdateVechileModelDto.TypeOfDrive;

            // Save the updated event
            await _unitOfWork.VechileModelRepository.UpdateAsync(existingVechileModel);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Updated Successfully.";
            response.Data = _mapper.Map<UpdateVechileModelDto>(existingVechileModel);

            return response;

            
        }
    }
}

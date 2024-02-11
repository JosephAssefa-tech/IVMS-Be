using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Inflations.DTOs;
using VechileManagement.Application.Features.Inflations.Requests.Command;
using VechileManagement.Application.Features.Inflations.Responses;
using VechileManagement.Application.Features.Inflations.Validators;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;
using VechileManagement.Application.Features.VechileModel.Validators;

namespace VechileManagement.Application.Features.Inflations.Handlers.Commands
{
    public class UpdateInflationCommandHandler : IRequestHandler<UpdateInflationCommand, UpdateInflationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateInflationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateInflationResponse> Handle(UpdateInflationCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInflationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateInflationDto);

            var response = new UpdateInflationResponse();
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            // Fetch the existing event by eventId
            var existingData = await _unitOfWork.InflationRepository.GetByIdAsync(request.UpdateInflationDto.Id);

            if (existingData == null)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = new List<string> { "Inflation Not Found." };
                return response;
            }


            existingData.ServiceYear = request.UpdateInflationDto.ServiceYear;
            existingData.Point = request.UpdateInflationDto.Point;
     

            // Save the updated event
            await _unitOfWork.InflationRepository.UpdateAsync(existingData);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Updated Successfully.";
            response.Data = _mapper.Map<UpdateInflationDto>(existingData);

            return response;
        }
    }
}

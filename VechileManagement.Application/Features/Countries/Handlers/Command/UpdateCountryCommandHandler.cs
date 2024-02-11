using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.Countries.Requests.Command;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.Countries.VAlidators;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;
using VechileManagement.Application.Features.VechileModel.Validators;

namespace VechileManagement.Application.Features.Countries.Handlers.Command
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, UpdateCountryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCountryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UpdateCountryResponse> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCounryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCountryDto);

            var response = new UpdateCountryResponse();
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            // Fetch the existing event by eventId
            var existingCountry = await _unitOfWork.countryRepository.GetByIdAsync(request.UpdateCountryDto.Id);

            if (existingCountry == null)
            {
                response.Success = false;
                response.Message = "Counry Updation Failed.";
                response.Errors = new List<string> { "Counry Not Found." };
                return response;
            }

            // Update the properties of the existing event
            existingCountry.CountryCode = request.UpdateCountryDto.CountryCode;
            existingCountry.CountryNameEng = request.UpdateCountryDto.CountryNameEng;
            existingCountry.CountryNameAmh = request.UpdateCountryDto.CountryNameAmh;
            existingCountry.Point = request.UpdateCountryDto.Point;


            // Save the updated event
            await _unitOfWork.countryRepository.UpdateAsync(existingCountry);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Updated Successfully.";
            response.Data = _mapper.Map<UpdateCountryDto>(existingCountry);

            return response;

        }
    }
}

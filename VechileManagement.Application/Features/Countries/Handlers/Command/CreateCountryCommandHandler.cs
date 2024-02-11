using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Countries.Requests.Command;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.Countries.VAlidators;
using VechileManagement.Application.Features.Countries.DTOs;

using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Features.Countries.Handlers.Command
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, CreateCountryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CreateCountryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }

        public async Task<CreateCountryResponse> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateCountryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCountryDto);
            var response = new CreateCountryResponse();

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            var country = _mapper.Map<Country>(request.CreateCountryDto);
            country = await _unitOfWork.countryRepository.AddAsync(country);

            await _unitOfWork.Save();

            response.Success = true;
            response.Message = " Country Created Successfully.";
            response.Data = _mapper.Map<CreateCountryDto>(country);

            return response;

        }
    }
}

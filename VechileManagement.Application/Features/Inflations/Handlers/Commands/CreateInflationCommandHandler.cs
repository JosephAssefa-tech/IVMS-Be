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
using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Features.Inflations.Handlers.Commands
{
    public class CreateInflationCommandHandler : IRequestHandler<CreateInflationCommand, CreateInflationResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateInflationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateInflationResponse> Handle(CreateInflationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateInflationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateInflationDto);

            var response = new CreateInflationResponse();

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Of Inflation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }
            var inflation = _mapper.Map<Inflation>(request.CreateInflationDto);
            inflation = await _unitOfWork.InflationRepository.AddAsync(inflation);

            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Created Successfully.";
            response.Data = _mapper.Map<CreateInflationDto>(inflation);

            return response;
        }
    }
}

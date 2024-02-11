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
using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Features.FactoryServiceTypeParameters.Handlers.Commands
{
    public class CreateFactoryServiceTypeParametersCommandHandler : IRequestHandler<CreateFactoryServiceTypeParametersCommand, CreateFactoryServiceTypeParametersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFactoryServiceTypeParametersCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<CreateFactoryServiceTypeParametersResponse> Handle(CreateFactoryServiceTypeParametersCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFactoryServiceTypeParameterDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateFactoryServiceTypeParameterDto);

            var response = new CreateFactoryServiceTypeParametersResponse();

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Of Inflation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }
            var data = _mapper.Map<FactoryServiceTypeParameter>(request.CreateFactoryServiceTypeParameterDto);
            data = await _unitOfWork.FactoryServiceTypeParameterRepository.AddAsync(data);

            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Created Successfully.";
            response.Data = _mapper.Map<CreateFactoryServiceTypeParameterDto>(data);

            return response;
        }
    }
}

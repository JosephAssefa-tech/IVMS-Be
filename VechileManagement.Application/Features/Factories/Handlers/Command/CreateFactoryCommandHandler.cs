using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Factories.DTOs;
using VechileManagement.Application.Features.Factories.Requests.Command;
using VechileManagement.Application.Features.Factories.Responses;
using VechileManagement.Application.Features.Factories.Validators;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Responses;
using VechileManagement.Application.Features.VechileModel.Validators;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Features.Factories.Handlers.Command
{
    public class CreateFactoryCommandHandler : IRequestHandler<CreateFactoryCommand, CreateFactoryResponse>
    {
     private readonly IUnitOfWork _unitOfWork;
     private readonly IMapper _mapper;
    public CreateFactoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

        public async Task<CreateFactoryResponse> Handle(CreateFactoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateFactoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateFactoryDto);

            var response = new CreateFactoryResponse();


            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Of Factory Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }
            var factory = _mapper.Map<Factory>(request.CreateFactoryDto);
            factory = await _unitOfWork.FactoryRepository.AddAsync(factory);

            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Created Successfully.";
            response.Data = _mapper.Map<CreateFactoryDto>(factory);

            return response;
        }
    }

 
}



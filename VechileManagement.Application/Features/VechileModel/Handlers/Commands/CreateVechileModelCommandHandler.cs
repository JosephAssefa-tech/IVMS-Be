using AutoMapper;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;
using VechileManagement.Application.Features.VechileModel.Validators;
using VechileManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VechileManagement.Application.Features.VechileModel.Handlers.Commands
{
    
    public class CreateVechileModelCommandHandler : IRequestHandler<CreateVechileModelCommand, CreateVechileModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateVechileModelCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateVechileModelResponse> Handle(CreateVechileModelCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateVechileModelDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateVechileModelDto);

            var response = new CreateVechileModelResponse();

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Of VechileMOdel Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }
            var vechile = _mapper.Map<VehicleModel>(request.CreateVechileModelDto);
            vechile = await _unitOfWork.VechileModelRepository.AddAsync(vechile);

            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Created Successfully.";
            response.Data = _mapper.Map<CreateVechileModelDto>(vechile);

            return response;
        }
    }
}

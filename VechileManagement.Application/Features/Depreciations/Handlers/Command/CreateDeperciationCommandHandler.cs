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
using VechileManagement.Application.Features.Depreciations.DTOs;
using VechileManagement.Application.Features.Depreciations.Requests.Command;
using VechileManagement.Application.Features.Depreciations.Response;
using VechileManagement.Application.Features.Depreciations.Validators;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Features.Depreciations.Handlers.Command
{
    public class CreateDeperciationCommandHandler : IRequestHandler<CreateDeperciationCommand, CreateDepreciationResponse>

    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public CreateDeperciationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;

        }



        public async Task<CreateDepreciationResponse> Handle(CreateDeperciationCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDeperciationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateDeperciationDto);
            var response = new CreateDepreciationResponse();

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            var depreciation = _mapper.Map<Depreciation>(request.CreateDeperciationDto);
            depreciation = await _unitOfWork.deperciationRepository.AddAsync(depreciation);

            await _unitOfWork.Save();

            response.Success = true;
            response.Message = " Country Created Successfully.";
            response.Data = _mapper.Map<CreateDeperciationDto>(depreciation);

            return response;
        }
    }
}

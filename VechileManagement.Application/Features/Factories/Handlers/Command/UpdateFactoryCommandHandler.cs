using AutoMapper;
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
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;
using VechileManagement.Application.Features.VechileModel.Validators;

namespace VechileManagement.Application.Features.Factories.Handlers.Command
{
    public class UpdateFactoryCommandHandler : IRequestHandler<UpdateFactoryCommand, UpdateFactoryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateFactoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateFactoryResponse> Handle(UpdateFactoryCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFactoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateFactoryDto);

            var response = new UpdateFactoryResponse();
            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }
            // Fetch the existing event by eventId
            var existingFactory = await _unitOfWork.FactoryRepository.GetByIdAsync(request.UpdateFactoryDto.Id);

            if (existingFactory == null)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = new List<string> { "Factory Not Found." };
                return response;
            }
            existingFactory.Code = request.UpdateFactoryDto.Code;
            existingFactory.FactoryNameEng = request.UpdateFactoryDto.FactoryNameEng;
            existingFactory.FactoryNameAmh = request.UpdateFactoryDto.FactoryNameAmh;

            // Save the updated event
            await _unitOfWork.FactoryRepository.UpdateAsync(existingFactory);
            await _unitOfWork.Save();


            response.Success = true;
            response.Message = "Updated Successfully.";
            response.Data = _mapper.Map<UpdateFactoryDto>(existingFactory);

            return response;

        }
    }
}

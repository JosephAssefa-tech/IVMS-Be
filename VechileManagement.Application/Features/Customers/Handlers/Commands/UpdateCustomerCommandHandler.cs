using AutoMapper;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Customers.DTOs;
using VechileManagement.Application.Features.Customers.Requests;
using VechileManagement.Application.Features.Customers.Responses;
using VechileManagement.Application.Features.Customers.Validators;
using VechileManagement.Domain.Entities;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System;

namespace VechileManagement.Application.Features.Customers.Handlers.Commands
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, UpdateCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateCustomerResponse> Handle(UpdateCustomerCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new UpdateCustomerDTOValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateCustomerDTO);

            var response = new UpdateCustomerResponse();

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
                return response;
            }

            var customer = _mapper.Map<Customer>(request.UpdateCustomerDTO);
            if(customer == null)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = new List<string> { "Customer Not Found."};
                return response;
            }

            await _unitOfWork.CustomerRepository.UpdateAsync(customer);

            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Updation Failed.";
                response.Errors = new List<string> { "Bad Request." };

                return response;
            }

            response.Success = true;
            response.Message = "Updated Successfully.";
            response.Data = _mapper.Map<UpdateCustomerDTO>(customer);

            return response;
        }
    }
}

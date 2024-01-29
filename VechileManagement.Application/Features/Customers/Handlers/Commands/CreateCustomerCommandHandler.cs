using AutoMapper;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Customers.DTOs;
using VechileManagement.Application.Features.Customers.Requests;
using VechileManagement.Application.Features.Customers.Responses;
using VechileManagement.Application.Features.Customers.Validators;
using VechileManagement.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VechileManagement.Application.Features.Customers.Handlers.Commands
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, 
            CancellationToken cancellationToken)
        {
            var validator = new CreateCustomerDTOValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCustomerDTO);

            var response = new CreateCustomerResponse();

            if(!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "Creation Failed.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            var customer = _mapper.Map<Customer>(request.CreateCustomerDTO);
            customer = await _unitOfWork.CustomerRepository.AddAsync(customer);
            
            await _unitOfWork.Save();
            
            response.Success = true;
            response.Message = "Created Successfully.";
            response.Data = _mapper.Map<CreateCustomerDTO>(customer);

            return response;
        }
    }
}

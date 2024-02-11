using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;
using System.Linq;

namespace VechileManagement.Application.Features.VechileModel.Handlers.Queries
{
    public class GetVechileModelRequestHandler : IRequestHandler<GetVechileModelRequest,GetVechileModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVechileModelRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetVechileModelResponse> Handle(GetVechileModelRequest request,
            CancellationToken cancellationToken)
        {
            //if you want to get all the data without filtering use the below commented code
            // var vechiles = (await _unitOfWork.VechileModelRepository.GetAllAsync()).OrderBy(c => c.Created);
            var vechiles = (await _unitOfWork.VechileModelRepository.FilterVechileModel(request.Model, request.FactoryId, request.FuelType,request.From, request.To));


            var response = new GetVechileModelResponse();
            response.Success = true;
            response.Data = _mapper.Map<VechileModelDto>(vechiles);
            return response;
        }

    }
}

using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.VechileModel.Handlers.Queries
{
    public class GetVechileModelsRequestHandler:IRequestHandler<GetVechileModelsRequest, GetVechilesModelResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetVechileModelsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetVechilesModelResponse> Handle(GetVechileModelsRequest request,
            CancellationToken cancellationToken)
        {
            //if you want to get all the data without filtering use the below commented code
            // var vechiles = (await _unitOfWork.VechileModelRepository.GetAllAsync()).OrderBy(c => c.Created);
            var vechiles = (await _unitOfWork.VechileModelRepository.GetAllAsync())
     .Where(c => !c.IsDeleted)
     .OrderBy(c => c.Created);



            var response = new GetVechilesModelResponse();
            response.Success = true;
            response.Data = _mapper.Map<List<ListVechileModelsDto>>(vechiles);
            return response;
        }

    
    }
}

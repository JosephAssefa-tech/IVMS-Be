using AutoMapper;
using MediatR;
using System;
using VechileManagement.Application.Features.Factories.Requests;
using VechileManagement.Application.Features.Factories.Responses;
using MediatR;
using VechileManagement.Application.Contracts.Persitence;
using System.Threading.Tasks;
using VechileManagement.Application.Features.Factories.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace VechileManagement.Application.Features.Factories.Handlers
{
    public class GetFactoriesRequestHandler:IRequestHandler<GetFactoriesRequest, GetFactoriesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetFactoriesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetFactoriesResponse> Handle(GetFactoriesRequest request, CancellationToken cancellationToken)
        {
            var vechiles = (await _unitOfWork.FactoryRepository.GetAllAsync()).OrderBy(c => c.Created);
            var response = new GetFactoriesResponse();
            response.Success = true;
            response.Data = _mapper.Map<List<ListFactoryDto>>(vechiles);
            return response;
        }
    }
}

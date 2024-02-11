using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Inflations.DTOs;
using VechileManagement.Application.Features.Inflations.Requests.Request;
using VechileManagement.Application.Features.Inflations.Responses;
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.Inflations.Handlers.Queries
{
    public class GetInflationsCommandHandler : IRequestHandler<GetInflationsRequest, GetInflationsResponse>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetInflationsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetInflationsResponse> Handle(GetInflationsRequest request, CancellationToken cancellationToken)
        {
            var inflation = (await _unitOfWork.InflationRepository.GetAllInflationsAsync())
  .OrderBy(c => c.Created);



            var response = new GetInflationsResponse();
            response.Success = true;
            response.Data = _mapper.Map<List<ListInflationDto>>(inflation);
            return response;
        }
    }
}

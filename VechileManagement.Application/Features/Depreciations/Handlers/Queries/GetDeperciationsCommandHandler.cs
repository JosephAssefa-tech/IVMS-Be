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
using VechileManagement.Application.Features.Countries.Requests.Request;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.Depreciations.DTOs;
using VechileManagement.Application.Features.Depreciations.Requests.Queries;
using VechileManagement.Application.Features.Depreciations.Response;

namespace VechileManagement.Application.Features.Depreciations.Handlers.Queries
{
    public class GetDeperciationsCommandHandler : IRequestHandler<GetDepreciationsRequest, GetDepreciationsResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetDeperciationsCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetDepreciationsResponse> Handle(GetDepreciationsRequest request, CancellationToken cancellationToken)
        {
            var deperciations = (await _unitOfWork.deperciationRepository.GetAllAsync())
  .OrderBy(c => c.Created);



            var response = new GetDepreciationsResponse();
            response.Success = true;
            response.Data = _mapper.Map<List<ListDeperciationDto>>(deperciations);
            return response;
        }
    }
}

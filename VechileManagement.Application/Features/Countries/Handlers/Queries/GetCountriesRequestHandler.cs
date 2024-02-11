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
using VechileManagement.Application.Features.VechileModel.DTOs;
using VechileManagement.Application.Features.VechileModel.Requests;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.Countries.Handlers.Queries
{
    public class GetCountriesRequestHandler : IRequestHandler<GetCountriesRequest, GetCountriesResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCountriesRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<GetCountriesResponse> Handle(GetCountriesRequest request, CancellationToken cancellationToken)
        {
            var countries = (await _unitOfWork.countryRepository.GetAllAsync())
  .OrderBy(c => c.Created);



            var response = new GetCountriesResponse();
            response.Success = true;
            response.Data = _mapper.Map<List<ListCountryDto>>(countries);
            return response;
        }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Depreciations.DTOs;
using VechileManagement.Application.Features.Depreciations.Response;
using VechileManagement.Application.Features.Factories.DTOs;
using VechileManagement.Application.Features.Factories.Responses;

namespace VechileManagement.Application.Features.Depreciations.Requests.Command
{
    public class CreateDeperciationCommand : IRequest<CreateDepreciationResponse>
    {
        public CreateDeperciationDto CreateDeperciationDto { get; set; }
    }
}

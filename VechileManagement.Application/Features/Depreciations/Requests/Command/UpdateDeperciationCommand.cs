using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Countries.DTOs;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.Depreciations.DTOs;
using VechileManagement.Application.Features.Depreciations.Response;

namespace VechileManagement.Application.Features.Depreciations.Requests.Command
{
    public class UpdateDeperciationCommand : IRequest<UpdateDepreciationResponse>
    {
        public UpdateDeperciationDto UpdateDeperciationDto { get; set; }
    }
}

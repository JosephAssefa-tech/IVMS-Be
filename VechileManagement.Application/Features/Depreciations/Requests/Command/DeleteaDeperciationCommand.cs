using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Countries.Response;
using VechileManagement.Application.Features.Depreciations.Response;

namespace VechileManagement.Application.Features.Depreciations.Requests.Command
{
    public class DeleteaDeperciationCommand : IRequest<DeleteDepreciationResponse>
    {
        public Guid Id { get; set; }
    }
}

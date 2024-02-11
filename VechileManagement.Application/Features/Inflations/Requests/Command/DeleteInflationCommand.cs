using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.Inflations.Responses;
using VechileManagement.Application.Features.VechileModel.Responses;

namespace VechileManagement.Application.Features.Inflations.Requests.Command
{
    public class DeleteInflationCommand : IRequest<DeleteInflationResponse>
    {
        public Guid Id { get; set; }
    }
}

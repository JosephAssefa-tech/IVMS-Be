using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Features.VechileModel.Responses;
using VechileManagement.Domain.Enums;

namespace VechileManagement.Application.Features.VechileModel.Requests
{
    public class GetVechileModelRequest: IRequest<GetVechileModelResponse> 
    {
        public string Model { get; set; }
        public Guid FactoryId { get; set; }
        public FuelType FuelType { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }

    }
}

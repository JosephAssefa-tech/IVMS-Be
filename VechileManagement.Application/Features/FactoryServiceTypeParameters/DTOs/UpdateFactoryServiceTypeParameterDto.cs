using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Application.Common;

namespace VechileManagement.Application.Features.FactoryServiceTypeParameters.DTOs
{
    public class UpdateFactoryServiceTypeParameterDto : BaseDTO
    {
        public Guid FactoryId { get; set; }
        public Guid VehicleServiceTypeId { get; set; }
        public int Point { get; set; }
    }
}

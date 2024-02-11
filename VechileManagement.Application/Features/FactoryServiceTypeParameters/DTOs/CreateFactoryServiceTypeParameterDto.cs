using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Application.Features.FactoryServiceTypeParameters.DTOs
{
    public class CreateFactoryServiceTypeParameterDto
    {
        public Guid FactoryId { get; set; }
        public Guid VehicleServiceTypeId { get; set; }
        public int Point { get; set; }

    }
}

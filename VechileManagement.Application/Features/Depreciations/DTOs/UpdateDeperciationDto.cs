using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Application.Features.Depreciations.DTOs
{
    public class UpdateDeperciationDto
    {
        public Guid Id { get; set; }
        public Guid VehicleServiceTypeId { get; set; }
        public int ServiceYear { get; set; }
        public int Point { get; set; }
    }
}

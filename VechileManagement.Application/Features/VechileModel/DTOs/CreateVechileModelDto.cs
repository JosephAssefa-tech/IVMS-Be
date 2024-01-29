using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Domain.Entities;
using VechileManagement.Domain.Enums;

namespace VechileManagement.Application.Features.VechileModel.DTOs
{
    public class CreateVechileModelDto
    {
        public string Model { get; set; }
        public decimal Width { get; set; }
        public decimal Length { get; set; }
        public decimal Height { get; set; }
        public int AxleDistance { get; set; }
        public int NumberOfAxle { get; set; }
        public int EngineCapacity { get; set; }
        public int NumberOfCylinder { get; set; }
        public int HorsePower { get; set; }
        public int NumberOfTyreF { get; set; }
        public int NumberOfTyreB { get; set; }
        public int GrossWeight { get; set; }
        public int NetWeight { get; set; }
        public int NumberOfSeat { get; set; }
        public int CargoCapacity { get; set; }
        public decimal TyreSizeF { get; set; }
        public decimal TyreSizeB { get; set; }
        public string TypeOfDrive { get; set; }
        // Foreign key property
        public Guid FactoryId { get; set; }
        // Navigation property
        //public Factory Factory { get; set; }
        public FuelType FuelType { get; set; }
    }
}

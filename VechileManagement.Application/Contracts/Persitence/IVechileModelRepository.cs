using VechileManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VechileManagement.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace VechileManagement.Application.Contracts.Persitence
{
    public interface IVechileModelRepository :  IAsyncRepository<VehicleModel>
    {
        Task<VehicleModel> FilterVechileModel(string model,Guid factoryId,FuelType fuel, DateTime? createdFrom, DateTime? createdTo);
        Task<IReadOnlyList<VehicleModel>> GetAllVechileModelAsync();
        Task ProcessExcelData(IFormFile file);

    }
}

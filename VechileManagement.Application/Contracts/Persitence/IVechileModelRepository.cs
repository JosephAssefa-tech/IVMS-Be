using VechileManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace VechileManagement.Application.Contracts.Persitence
{
    public interface IVechileModelRepository :  IAsyncRepository<VehicleModel>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Contracts.Persitence
{
    public interface IFactoryServiceTypeParameterRepository : IAsyncRepository<FactoryServiceTypeParameter>
    {
        Task<IReadOnlyList<FactoryServiceTypeParameter>> GetAllFactoryServiceTypeParameterAsync();
    }
}

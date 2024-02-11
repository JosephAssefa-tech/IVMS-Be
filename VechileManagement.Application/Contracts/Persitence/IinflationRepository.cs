using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Contracts.Persitence
{
    public interface IinflationRepository : IAsyncRepository<Inflation>
    {
        Task<IReadOnlyList<Inflation>> GetAllInflationsAsync();
    }
}

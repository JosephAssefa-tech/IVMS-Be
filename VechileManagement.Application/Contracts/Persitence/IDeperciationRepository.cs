using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Contracts.Persitence
{
    public interface IDeperciationRepository : IAsyncRepository<Depreciation>
    {
        Task<IReadOnlyList<Depreciation>> GetAllDeperciationAsync();
    }
}

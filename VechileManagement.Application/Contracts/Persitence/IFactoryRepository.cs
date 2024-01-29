using System;
using System.Collections.Generic;
using System.Text;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Contracts.Persitence
{
    public interface  IFactoryRepository : IAsyncRepository<Factory>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Persistence.Repositories
{
    public class FactoryRepository : BaseRepository<Factory>, IFactoryRepository
    {
        public FactoryRepository(VechileMgtDbContext dbContext) : base(dbContext)
        {
        }
    }
}

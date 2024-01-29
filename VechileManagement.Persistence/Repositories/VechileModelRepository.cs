using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VechileManagement.Persistence.Repositories
{
    public class VechileModelRepository : BaseRepository<VehicleModel>, IVechileModelRepository
    {
        public VechileModelRepository(VechileMgtDbContext dbContext) : base(dbContext)
        {

        }
    }
}

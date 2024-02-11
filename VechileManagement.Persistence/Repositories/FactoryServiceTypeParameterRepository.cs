using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Persistence.Repositories
{
    public class FactoryServiceTypeParameterRepository : BaseRepository<FactoryServiceTypeParameter>, IFactoryServiceTypeParameterRepository
    {
        private readonly VechileMgtDbContext _dbContext;
        public FactoryServiceTypeParameterRepository(VechileMgtDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<FactoryServiceTypeParameter>> GetAllFactoryServiceTypeParameterAsync()
        {
            var data = await _dbContext.FactoryServiceTypeParameters

                    .Where(c => !c.IsDeleted).

                    ToListAsync();


            return data;
        }
    }
}

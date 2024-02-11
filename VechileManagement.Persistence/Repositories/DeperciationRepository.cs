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
    public class DeperciationRepository : BaseRepository<Depreciation>, IDeperciationRepository
    {
        private readonly VechileMgtDbContext _dbContext;
        public DeperciationRepository(VechileMgtDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<Depreciation>> GetAllDeperciationAsync()
        {
            var depreciations = await _dbContext.Depreciations 

                .Where(c => !c.IsDeleted).

                ToListAsync();


            return depreciations;

        }
    }
}

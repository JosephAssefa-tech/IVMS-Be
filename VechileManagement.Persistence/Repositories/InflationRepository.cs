using DocumentFormat.OpenXml.InkML;
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
    public class InflationRepository : BaseRepository<Inflation>, IinflationRepository
    {
        private readonly VechileMgtDbContext _dbContext;
        public InflationRepository(VechileMgtDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public  async Task<IReadOnlyList<Inflation>> GetAllInflationsAsync()
        {     
                var inflations = await _dbContext.Inflations

                    .Where(c => !c.IsDeleted).

                    ToListAsync();


                return inflations;
         
        }
    }
}

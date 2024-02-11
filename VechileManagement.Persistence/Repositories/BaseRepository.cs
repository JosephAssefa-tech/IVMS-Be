using VechileManagement.Application.Contracts.Persitence;
using Microsoft.EntityFrameworkCore;
using VechileManagement.Domain.Common;

namespace VechileManagement.Persistence.Repositories
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        private readonly VechileMgtDbContext _dbContext;

        public BaseRepository(VechileMgtDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        //public async Task<IReadOnlyList<T>> GetAllAsyncSoftDeleted()
        //{
        //    return await _dbContext.Set<T>().Where(entity =>
        //        entity.IsDeleted
        //    ).ToListAsync();
        //}


        public virtual async Task<T> GetByIdAsync(Guid Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            
            return entity;
        }
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task SoftDeleteAsync(T entity)
        {
       
                if (entity is BaseAuditableEntity baseAuditableEntity)
                {
                    baseAuditableEntity.IsDeleted = true;

                    // Log or debug the entity state
                    Console.WriteLine($"Entity State before modification: {_dbContext.Entry(entity).State}");

                    _dbContext.Entry(entity).State = EntityState.Modified;

                    // Log or debug the entity state after modification
                    Console.WriteLine($"Entity State after modification: {_dbContext.Entry(entity).State}");
                }
        

        }


     
    }
}

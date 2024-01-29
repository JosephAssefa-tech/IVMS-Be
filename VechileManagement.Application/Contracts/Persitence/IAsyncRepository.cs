using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VechileManagement.Application.Contracts.Persitence
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<T> GetByIdAsync(Guid Id);
        Task<IReadOnlyList<T>> GetAllAsync();
       // Task<IReadOnlyList<T>> GetAllAsyncSoftDeleted();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task SoftDeleteAsync(T entity);
    }
}

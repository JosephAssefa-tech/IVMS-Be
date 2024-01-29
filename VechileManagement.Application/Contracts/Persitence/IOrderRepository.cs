using VechileManagement.Domain.Entities;

namespace VechileManagement.Application.Contracts.Persitence
{
    public interface IOrderRepository : IAsyncRepository<Order>
    {
    }
}

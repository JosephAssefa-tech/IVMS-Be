using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Persistence.Repositories
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(VechileMgtDbContext dbContext) : base(dbContext)
        {

        }
    }
}

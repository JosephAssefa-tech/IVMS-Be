using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Domain.Entities;

namespace VechileManagement.Persistence.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(VechileMgtDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}

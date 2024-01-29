using VechileManagement.Application.Contracts.Persitence;

namespace VechileManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VechileMgtDbContext _dbContext;

        private ICustomerRepository _customerRepository;
        private IOrderRepository _orderRepository;
        private IVechileModelRepository _vechileRepository;
        private IFactoryRepository _FactoryRepository;



        public UnitOfWork(VechileMgtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICustomerRepository CustomerRepository => 
            _customerRepository ??= new CustomerRepository(_dbContext);

        public IOrderRepository OrderRepository => 
            _orderRepository ??= new OrderRepository(_dbContext);

        public IVechileModelRepository VechileModelRepository =>
              _vechileRepository ??= new VechileModelRepository(_dbContext);

        public IFactoryRepository FactoryRepository =>
            _FactoryRepository ??= new FactoryRepository(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}

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
        private ICountryRepository _CountryRepository;
        private IinflationRepository _InflationRepository;
        private IDeperciationRepository _deperciationRepository;
        private IFactoryServiceTypeParameterRepository _FactoryServiceTypeParameterRepository;
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

        public ICountryRepository countryRepository =>
             _CountryRepository ??= new CountryRepository(_dbContext);

        public IinflationRepository InflationRepository =>
            _InflationRepository ??= new InflationRepository(_dbContext);


        public IDeperciationRepository deperciationRepository =>
            _deperciationRepository ??= new DeperciationRepository(_dbContext);

        public IFactoryServiceTypeParameterRepository FactoryServiceTypeParameterRepository =>
           _FactoryServiceTypeParameterRepository ??= new FactoryServiceTypeParameterRepository(_dbContext);


        
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

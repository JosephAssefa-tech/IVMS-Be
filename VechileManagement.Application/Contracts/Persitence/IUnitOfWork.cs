using System;
using System.Threading.Tasks;

namespace VechileManagement.Application.Contracts.Persitence
{
    public interface IUnitOfWork : IDisposable
    {
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IVechileModelRepository VechileModelRepository { get; }
        IFactoryRepository FactoryRepository { get; }

        ICountryRepository countryRepository { get; }
        IinflationRepository InflationRepository { get; }
        IDeperciationRepository deperciationRepository { get; }
        Task Save();
    }
}

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



        Task Save();
    }
}

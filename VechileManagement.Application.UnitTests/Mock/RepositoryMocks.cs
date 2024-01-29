using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Domain.Entities;
using Moq;


namespace VechileManagement.Application.UnitTests.Mock
{
    public static class RepositoryMocks
    {
        public static Mock<IUnitOfWork> GetCustomerRepository() 
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Cust1 Name",
                    Address = new Domain.ValueObjects.Address
                    (
                        "street1", 
                        "city1", 
                        "state1", 
                        "country1", 
                        "zip1"
                        ),
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Cust2 Name",
                    Address = new Domain.ValueObjects.Address
                    (
                        "street2",
                        "city2",
                        "state2",
                        "country2",
                        "zip"
                        ),
                }
            };

            var mockCustomerRepository = new Mock<IUnitOfWork>();

            mockCustomerRepository.Setup(repo => repo.CustomerRepository.GetAllAsync())
                .ReturnsAsync(customers);

            mockCustomerRepository.Setup(repo => repo.CustomerRepository.AddAsync(It.IsAny<Customer>()))
                .ReturnsAsync(
                    (Customer customer) =>
                    {
                        customers.Add(customer);
                        return customer;
                    });

            return mockCustomerRepository;
        }
    }
}

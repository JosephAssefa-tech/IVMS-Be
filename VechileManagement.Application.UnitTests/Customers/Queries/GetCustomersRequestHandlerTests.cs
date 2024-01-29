using AutoMapper;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Customers.Handlers.Queries;
using VechileManagement.Application.Features.Customers.Requests;
using VechileManagement.Application.Features.Customers.Responses;
using VechileManagement.Application.Profiles;
using VechileManagement.Application.UnitTests.Mock;
using Moq;
using Shouldly;


namespace VechileManagement.Application.UnitTests.Customers.Queries
{
    public class GetCustomersRequestHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockCustomerRepository;

        public GetCustomersRequestHandlerTests()
        {
            _mockCustomerRepository = RepositoryMocks.GetCustomerRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetCustomersListTest()
        {
            var handler = new GetCustomersRequestHandler(_mockCustomerRepository.Object, _mapper);
            var result = await handler.Handle(new GetCustomersRequest(), CancellationToken.None);

            result.ShouldBeOfType<GetCustomersResponse>();
            result.Data.Count.ShouldBe(2);
        }
    }
}

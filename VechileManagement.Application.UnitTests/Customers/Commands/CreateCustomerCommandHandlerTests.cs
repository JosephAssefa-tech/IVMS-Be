using AutoMapper;
using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Application.Features.Customers.DTOs;
using VechileManagement.Application.Features.Customers.Handlers.Commands;
using VechileManagement.Application.Features.Customers.Requests;
using VechileManagement.Application.Features.Customers.Responses;
using VechileManagement.Application.Profiles;
using VechileManagement.Application.UnitTests.Mock;
using Moq;
using Shouldly;

namespace VechileManagement.Application.UnitTests.Customers.Commands
{
    public class CreateCustomerCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockCustomerRepository;
        private readonly CreateCustomerDTO _createCustomerDTO;
        private readonly CreateCustomerCommandHandler _createCustomerCommandHandler;

        public CreateCustomerCommandHandlerTests()
        {
            _mockCustomerRepository = RepositoryMocks.GetCustomerRepository();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _createCustomerCommandHandler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object, _mapper);

            _createCustomerDTO = new CreateCustomerDTO
            {
                Id = Guid.NewGuid(),
                Name = "New Cust",
                Address = new Domain.ValueObjects.Address
                (
                    "new street",
                    "new city",
                    "new state",
                    "new country",
                    "new zip"
                )
            };
        }

        [Fact]
        public async Task Should_Create_Customer()
        {
            var result = await _createCustomerCommandHandler.Handle(new CreateCustomerCommand() { CreateCustomerDTO = _createCustomerDTO}
                , CancellationToken.None);

            var customers = await _mockCustomerRepository.Object.CustomerRepository.GetAllAsync();

            result.ShouldBeOfType<CreateCustomerResponse>();
            result.Success.ShouldBeTrue();
            customers.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Should_Not_Create_Customer()
        {
            _createCustomerDTO.Name = null;
            var result = await _createCustomerCommandHandler.Handle(new CreateCustomerCommand() { CreateCustomerDTO = _createCustomerDTO }
                , CancellationToken.None);

            var customers = await _mockCustomerRepository.Object.CustomerRepository.GetAllAsync();

            result.ShouldBeOfType<CreateCustomerResponse>();
            result.Success.ShouldBeFalse();
            customers.Count.ShouldBe(2);
        }

        [Fact]
        public async Task Should_Show_Error_Message()
        {
            _createCustomerDTO.Name = string.Empty;
            var result = await _createCustomerCommandHandler.Handle(new CreateCustomerCommand() { CreateCustomerDTO = _createCustomerDTO }
                , CancellationToken.None);

            var customers = await _mockCustomerRepository.Object.CustomerRepository.GetAllAsync();

            result.Errors[0].ShouldBe("Name is required.");
        }
    }
}

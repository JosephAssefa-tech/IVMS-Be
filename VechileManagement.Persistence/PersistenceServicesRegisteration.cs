using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VechileManagement.Application.Contracts.Persitence;

namespace VechileManagement.Persistence
{
    public static class PersistenceServicesRegisteration
    {
        public static IServiceCollection AddPersistenceServices (
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<VechileMgtDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString
                ("VechileManagementConnectionString")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));   

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }
    }
}

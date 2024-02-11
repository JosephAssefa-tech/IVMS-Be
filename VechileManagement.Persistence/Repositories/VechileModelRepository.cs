using VechileManagement.Application.Contracts.Persitence;
using VechileManagement.Domain.Entities;
using System;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using VechileManagement.Domain.Enums;
using Microsoft.EntityFrameworkCore;


namespace VechileManagement.Persistence.Repositories
{
    public class VechileModelRepository : BaseRepository<VehicleModel>, IVechileModelRepository
    {
        private readonly VechileMgtDbContext _dbContext;

        public VechileModelRepository(VechileMgtDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<VehicleModel> FilterVechileModel(string model, Guid factoryId, FuelType fuel, DateTime? createdFrom, DateTime? createdTo)
        {
            // Log values for troubleshooting
            Console.WriteLine($"Model: {model}, FactoryId: {factoryId}, Fuel: {fuel}");

            // Check if the provided fuel value is a valid FuelType enum value
            if (!Enum.IsDefined(typeof(FuelType), fuel))
            {
                Console.WriteLine("Invalid FuelType value");
                return null; // Or handle the error accordingly
            }

            var filteredModel = await _dbContext.VehicleModels
                 .Where(c => !c.IsDeleted)
                .Where(x =>
                    (string.IsNullOrEmpty(model) || x.Model.ToLower() == model.ToLower()) &&
                    (factoryId == Guid.Empty || x.FactoryId == factoryId) &&
                    (x.FuelType == (FuelType)fuel) &&
                    (!createdFrom.HasValue || x.Created >= createdFrom) &&
                    (!createdTo.HasValue || x.Created <= createdTo))
                .Where(c => !c.IsDeleted)
                .FirstOrDefaultAsync();

            // Log the generated SQL query
            var sqlQuery = _dbContext.VehicleModels.Where(x =>
                    (x.Model.ToLower() == model) &&
                    (factoryId == Guid.Empty || x.FactoryId == factoryId) &&
                    (x.FuelType == (FuelType)fuel))
                .ToQueryString();

            Console.WriteLine($"Generated SQL Query: {sqlQuery}");

            return filteredModel;
        }

        public async Task<IReadOnlyList<VehicleModel>> GetAllVechileModelAsync()
        {
            var vechileModels = await _dbContext.VehicleModels
                .Include(e => e.Factory).

                Where(c => !c.IsDeleted).

                ToListAsync();


            return vechileModels;
        }

        public async Task ProcessExcelData(IFormFile file)
        {
          
        }

    }

}

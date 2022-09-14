using EquinityCommerceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EquinityCommerceApp.DataAccess.Data
{
    public class EquinityAppDbContextSeed
    {
        private static IEnumerable<Category> GetPreConfiguredCategories()
        {
            var categories = new List<Category>
            {
                new Category{ Name="Fiction", DisplayOrder=1, CreatedDateTime=DateTime.Now},
                new Category{ Name="Non-Fiction", DisplayOrder=2, CreatedDateTime=DateTime.Now},
            };
            return categories;
        }
        private static IEnumerable<CoverType> GetPreConfiguredCoverTypes()
        {
            var coverTypes = new List<CoverType>
            {
                new CoverType{ Name="Hardcover"},
                new CoverType{ Name="Paperback"},
            };
            return coverTypes;
        }
        private static IEnumerable<Product> GetPreConfiguredProducts()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Title="The Alchemist",
                    ISBN="1234567890",
                    ImageUrl="",
                    Description="New book from Paul Cohelo",
                    Author="Paul Cohelo",
                    ListPrice = 499,
                    Price=399,
                    PriceFifty=349,
                    PriceHundred=299,
                    CategoryId=107,
                    CoverTypeId=100
                }
            };
            return products;
        }
        public static async Task SeedAsync(EquinityAppDbContext dbContext, ILoggerFactory loggerFactory, int? retryAttempt = 0)
        {
            int retryCount = retryAttempt ?? 0;
            try
            {
                dbContext.Database.Migrate();
                if (!dbContext.Categories.Any())
                {
                    var categories = GetPreConfiguredCategories();
                    dbContext.Categories.AddRange(categories);
                    await dbContext.SaveChangesAsync();
                }
                if (!dbContext.CoverTypes.Any())
                {
                    var coverTypes = GetPreConfiguredCoverTypes();
                    dbContext.CoverTypes.AddRange(coverTypes);
                    await dbContext.SaveChangesAsync();
                }
                if (!dbContext.Products.Any())
                {
                    var products = GetPreConfiguredProducts();
                    dbContext.Products.AddRange(products);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryCount < 5)
                {
                    retryCount++;
                    var logger = loggerFactory.CreateLogger<EquinityAppDbContext>();
                    logger.LogError(ex.Message);
                    await SeedAsync(dbContext, loggerFactory, retryAttempt);
                }
                throw;
            }
        }
    }
}

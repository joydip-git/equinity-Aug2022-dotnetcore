using EquinityCommerceApp.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquinityCommerceApp.Web.Repositories
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
            }
            catch (Exception ex)
            {
                if (retryCount < 5)
                {
                    retryCount++;
                    var logger = loggerFactory.CreateLogger<EquinityAppDbContext>();
                    logger.LogError(ex.Message);
                    await SeedAsync(dbContext,loggerFactory, retryAttempt);
                }
                throw;
            }
        }
    }
}

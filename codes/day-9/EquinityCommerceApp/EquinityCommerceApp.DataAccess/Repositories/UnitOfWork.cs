using EquinityCommerceApp.Core.Repositories;
using EquinityCommerceApp.DataAccess.Data;
using EquinityCommerceApp.DataAccess.Repositories.Base;

namespace EquinityCommerceApp.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(EquinityAppDbContext dbContext)
        {
            Category = new CategoryRepository(dbContext);
            CoverType = new CoverTypeRepository(dbContext);
            Product = new ProductRepository(dbContext);
        }
        public ICategoryRepository Category { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; }

        public IProductRepository Product { get; private set; }
    }
}

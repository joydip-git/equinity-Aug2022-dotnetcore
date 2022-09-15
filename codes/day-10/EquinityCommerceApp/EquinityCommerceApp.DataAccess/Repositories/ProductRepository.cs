using EquinityCommerceApp.Core.Entities;
using EquinityCommerceApp.Core.Repositories;
using EquinityCommerceApp.DataAccess.Data;
using EquinityCommerceApp.DataAccess.Repositories.Base;

namespace EquinityCommerceApp.DataAccess.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly EquinityAppDbContext _context;
        public ProductRepository(EquinityAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _context.Set<Product>().Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}

using EquinityCommerceApp.Core.Entities;
using EquinityCommerceApp.Core.Repositories.Base;

namespace EquinityCommerceApp.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> UpdateAsync(Product product);
    }
}

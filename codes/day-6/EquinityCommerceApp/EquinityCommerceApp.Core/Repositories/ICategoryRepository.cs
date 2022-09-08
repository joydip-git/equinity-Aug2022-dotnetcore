using EquinityCommerceApp.Core.Entities;
using EquinityCommerceApp.Core.Repositories.Base;

namespace EquinityCommerceApp.Core.Repositories
{
    public interface ICategoryRepository:IRepository<Category>
    {
        Task<Category> UpdateAsync(Category category);
    }
}

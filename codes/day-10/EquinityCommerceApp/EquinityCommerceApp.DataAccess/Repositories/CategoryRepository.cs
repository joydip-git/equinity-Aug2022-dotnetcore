using EquinityCommerceApp.Core.Entities;
using EquinityCommerceApp.Core.Repositories;
using EquinityCommerceApp.DataAccess.Data;
using EquinityCommerceApp.DataAccess.Repositories.Base;

namespace EquinityCommerceApp.DataAccess.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly EquinityAppDbContext _context;
        public CategoryRepository(EquinityAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Set<Category>().Update(category);
            await _context.SaveChangesAsync();
            return category;
        }
    }
}

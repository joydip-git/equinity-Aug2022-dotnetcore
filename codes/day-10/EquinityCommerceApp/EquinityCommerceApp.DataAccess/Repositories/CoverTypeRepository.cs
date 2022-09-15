using EquinityCommerceApp.Core.Entities;
using EquinityCommerceApp.Core.Repositories;
using EquinityCommerceApp.DataAccess.Data;
using EquinityCommerceApp.DataAccess.Repositories.Base;

namespace EquinityCommerceApp.DataAccess.Repositories
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private readonly EquinityAppDbContext _context;
        public CoverTypeRepository(EquinityAppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<CoverType> UpdateAsync(CoverType coverType)
        {
            _context.Set<CoverType>().Update(coverType);
            await _context.SaveChangesAsync();
            return coverType;
        }
    }
}

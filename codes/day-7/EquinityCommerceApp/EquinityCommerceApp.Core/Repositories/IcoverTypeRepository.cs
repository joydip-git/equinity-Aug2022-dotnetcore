using EquinityCommerceApp.Core.Entities;
using EquinityCommerceApp.Core.Repositories.Base;

namespace EquinityCommerceApp.Core.Repositories
{
    public interface ICoverTypeRepository:IRepository<CoverType>
    {
        Task<CoverType> UpdateAsync(CoverType coverType);
    }
}

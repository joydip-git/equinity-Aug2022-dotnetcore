using EquinityCommerceApp.Core.Repositories;

namespace EquinityCommerceApp.DataAccess.Repositories.Base
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }
    }
}

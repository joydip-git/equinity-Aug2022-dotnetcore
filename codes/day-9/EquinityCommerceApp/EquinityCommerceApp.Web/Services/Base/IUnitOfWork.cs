using EquinityCommerceApp.Web.Models;

namespace EquinityCommerceApp.Web.Services.Base
{
    public interface IUnitOfWork
    {
        IApiService<CategoryModel> CategoryService { get; }
        IApiService<CoverTypeModel> CoverTypeService { get; }
        IApiService<ProductModel> ProductService { get; }
    }
}

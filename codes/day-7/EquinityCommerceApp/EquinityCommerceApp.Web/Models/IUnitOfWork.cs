using EquinityCommerceApp.Web.Services;

namespace EquinityCommerceApp.Web.Models
{
    public interface IUnitOfWork
    {
        IApiService<CategoryModel> CategoryService { get; }
        IApiService<CoverTypeModel> CoverTypeService { get; }
    }
}

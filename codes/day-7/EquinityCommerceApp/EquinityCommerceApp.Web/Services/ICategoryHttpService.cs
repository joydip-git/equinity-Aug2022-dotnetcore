using EquinityCommerceApp.Web.Models;

namespace EquinityCommerceApp.Web.Services
{
    public interface ICategoryHttpService
    {
        Task<ApiResponseModel<CategoryModel>> GetCategoryAsync(int id);
        Task<ApiResponseModel<IEnumerable<CategoryModel>>> GetAllCategoriesAsync();
        Task<ApiResponseModel<CategoryModel>> AddCategoryAsync(CategoryModel category);
        Task<ApiResponseModel<CategoryModel>> UpdateCategoryAsync(CategoryModel category);
        Task<ApiResponseModel<CategoryModel>> DeleteCategoryAsync(int id);
    }
}

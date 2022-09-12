using EquinityCommerceApp.Web.Models;

namespace EquinityCommerceApp.Web.Services
{
    public interface IApiService<T>
    {
        Task<ApiResponseModel<T>> GetAsync(int? id);
        Task<ApiResponseModel<IEnumerable<T>>> GetAllAsync();
        Task<ApiResponseModel<T>> AddAsync(T modelType);
        Task<ApiResponseModel<T>> UpdateAsync(T modelType);
        Task<ApiResponseModel<T>> DeleteAsync(int? id);
    }
}

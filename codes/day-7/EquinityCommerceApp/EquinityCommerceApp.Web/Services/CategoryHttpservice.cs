using EquinityCommerceApp.Web.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EquinityCommerceApp.Web.Services
{
    public class CategoryHttpservice : ICategoryHttpService
    {
        /*
        private readonly HttpClient _httpClient;

        public CategoryHttpservice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        */

        private readonly IOptions<ApiUrls> apiRuls;
        private readonly ILogger<CategoryHttpservice> logger;
        private readonly string categoryApiUrl;

        public CategoryHttpservice(IOptions<ApiUrls> apiRuls, ILogger<CategoryHttpservice> logger)
        {
            this.apiRuls = apiRuls;
            this.logger = logger;
            categoryApiUrl = apiRuls.Value.CategoryApiUrl;
        }

        public async Task<ApiResponseModel<CategoryModel>> AddCategoryAsync(CategoryModel category)
        {
            ApiResponseModel<CategoryModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PostAsJsonAsync<CategoryModel>(categoryApiUrl, category);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<CategoryModel>>(result);
            }
            return response;
        }

        public async Task<ApiResponseModel<CategoryModel>> DeleteCategoryAsync(int id)
        {
            var url = $"{categoryApiUrl}/{id}";
            ApiResponseModel<CategoryModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.DeleteAsync(url);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<CategoryModel>>(result);
            }
            return response;
        }

        public async Task<ApiResponseModel<IEnumerable<CategoryModel>>> GetAllCategoriesAsync()
        {
            ApiResponseModel<IEnumerable<CategoryModel>> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<IEnumerable<CategoryModel>>>(categoryApiUrl);
            }
            return response;
        }

        public async Task<ApiResponseModel<CategoryModel>> GetCategoryAsync(int id)
        {
            var url = $"{categoryApiUrl}/{id}";
            ApiResponseModel<CategoryModel> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<CategoryModel>>(url);
            }
            return response;
        }

        public async Task<ApiResponseModel<CategoryModel>> UpdateCategoryAsync(CategoryModel category)
        {
            ApiResponseModel<CategoryModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PutAsJsonAsync<CategoryModel>(categoryApiUrl, category);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<CategoryModel>>(result);
            }
            return response;
        }
    }
}

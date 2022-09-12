using EquinityCommerceApp.Web.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EquinityCommerceApp.Web.Services
{
    public class CategoryHttpservice : IApiService<CategoryModel>
    {
        /*
        private readonly HttpClient _httpClient;

        public CategoryHttpservice(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        */

        private readonly IOptions<ApiUrls> apiUrls;
        private readonly ILogger<CategoryHttpservice> logger;
        private readonly ILoggerFactory loggerFactory;        
        private readonly string categoryApiUrl;

        public CategoryHttpservice(IOptions<ApiUrls> apiUrls, ILoggerFactory loggerFactory)
        {
            this.apiUrls = apiUrls;
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory.CreateLogger<CategoryHttpservice>();
            categoryApiUrl = apiUrls.Value.CategoryApiUrl;
        }

        public async Task<ApiResponseModel<CategoryModel>> AddAsync(CategoryModel category)
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

        public async Task<ApiResponseModel<CategoryModel>> DeleteAsync(int? id)
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

        public async Task<ApiResponseModel<IEnumerable<CategoryModel>>> GetAllAsync()
        {
            ApiResponseModel<IEnumerable<CategoryModel>> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<IEnumerable<CategoryModel>>>(categoryApiUrl);
            }
            return response;
        }

        public async Task<ApiResponseModel<CategoryModel>> GetAsync(int? id)
        {
            var url = $"{categoryApiUrl}/{id}";
            ApiResponseModel<CategoryModel> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<CategoryModel>>(url);
            }
            return response;
        }

        public async Task<ApiResponseModel<CategoryModel>> UpdateAsync(CategoryModel category)
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

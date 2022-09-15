using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services.Base;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EquinityCommerceApp.Web.Services
{
    public class ProductHttpservice : IApiService<ProductModel>
    {       
        private readonly IOptions<ApiUrls> apiUrls;
        private readonly ILogger<ProductHttpservice> logger;
        private readonly ILoggerFactory loggerFactory;        
        private readonly string productApiUrl;

        public ProductHttpservice(IOptions<ApiUrls> apiUrls, ILoggerFactory loggerFactory)
        {
            this.apiUrls = apiUrls;
            this.loggerFactory = loggerFactory;
            this.logger = loggerFactory.CreateLogger<ProductHttpservice>();
            productApiUrl = apiUrls.Value.ProductApiUrl;
        }

        public async Task<ApiResponseModel<ProductModel>> AddAsync(ProductModel productModel)
        {
            ApiResponseModel<ProductModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PostAsJsonAsync<ProductModel>(productApiUrl, productModel);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<ProductModel>>(result);
            }
            return response;
        }

        public async Task<ApiResponseModel<ProductModel>> DeleteAsync(int? id)
        {
            var url = $"{productApiUrl}/{id}";
            ApiResponseModel<ProductModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.DeleteAsync(url);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<ProductModel>>(result);
            }
            return response;
        }

        public async Task<ApiResponseModel<IEnumerable<ProductModel>>> GetAllAsync()
        {
            ApiResponseModel<IEnumerable<ProductModel>> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<IEnumerable<ProductModel>>>(productApiUrl);
            }
            return response;
        }

        public async Task<ApiResponseModel<ProductModel>> GetAsync(int? id)
        {
            var url = $"{productApiUrl}/{id}";
            ApiResponseModel<ProductModel> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<ProductModel>>(url);
            }
            return response;
        }

        public async Task<ApiResponseModel<ProductModel>> UpdateAsync(ProductModel productModel)
        {
            ApiResponseModel<ProductModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PutAsJsonAsync<ProductModel>(productApiUrl, productModel);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<ProductModel>>(result);
            }
            return response;
        }
    }
}

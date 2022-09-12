using EquinityCommerceApp.Web.Models;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EquinityCommerceApp.Web.Services
{
    public class CoverTypeHttpService : IApiService<CoverTypeModel>
    {
        private readonly IOptions<ApiUrls> apiUrls;
        private readonly ILogger<CoverTypeHttpService> logger;
        private readonly ILoggerFactory factory;
        private readonly string coverTypeApiUrl;

        public CoverTypeHttpService(IOptions<ApiUrls> apiUrls, ILoggerFactory loggerFactory)
        {
            this.apiUrls = apiUrls;
            this.factory = loggerFactory; 
            this.logger = this.factory.CreateLogger<CoverTypeHttpService>();
            this.coverTypeApiUrl = apiUrls.Value.CoverTypeApiUrl; ;
        }

        public async Task<ApiResponseModel<CoverTypeModel>> AddAsync(CoverTypeModel coverType)
        {
            ApiResponseModel<CoverTypeModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PostAsJsonAsync<CoverTypeModel>(coverTypeApiUrl, coverType);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<CoverTypeModel>>(result);
            }
            return response;
        }

        public async Task<ApiResponseModel<CoverTypeModel>> DeleteAsync(int? id)
        {
            var url = $"{coverTypeApiUrl}/{id}";
            ApiResponseModel<CoverTypeModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.DeleteAsync(url);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<CoverTypeModel>>(result);
            }
            return response;
        }

        public async Task<ApiResponseModel<IEnumerable<CoverTypeModel>>> GetAllAsync()
        {
            ApiResponseModel<IEnumerable<CoverTypeModel>> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<IEnumerable<CoverTypeModel>>>(coverTypeApiUrl);
            }
            return response;
        }

        public async Task<ApiResponseModel<CoverTypeModel>> GetAsync(int? id)
        {
            var url = $"{coverTypeApiUrl}/{id}";
            ApiResponseModel<CoverTypeModel> response = null;
            using (var client = new HttpClient())
            {
                response = await client.GetFromJsonAsync<ApiResponseModel<CoverTypeModel>>(url);
            }
            return response;
        }

        public async Task<ApiResponseModel<CoverTypeModel>> UpdateAsync(CoverTypeModel coverType)
        {
            ApiResponseModel<CoverTypeModel> response = null;
            using (var client = new HttpClient())
            {
                var httpResponse = await client.PutAsJsonAsync<CoverTypeModel>(coverTypeApiUrl, coverType);
                var result = await httpResponse.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<ApiResponseModel<CoverTypeModel>>(result);
            }
            return response;
        }
    }
}

using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services.Base;
using Microsoft.Extensions.Options;

namespace EquinityCommerceApp.Web.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOptions<ApiUrls> apiUrls;

        public UnitOfWork(IOptions<ApiUrls> apiUrls, ILoggerFactory factory)
        {
            CategoryService = new CategoryHttpservice(apiUrls, factory);
            CoverTypeService = new CoverTypeHttpService(apiUrls, factory);
        }

        public IApiService<CategoryModel> CategoryService { get; private set; }

        public IApiService<CoverTypeModel> CoverTypeService { get; private set; }
    }
}

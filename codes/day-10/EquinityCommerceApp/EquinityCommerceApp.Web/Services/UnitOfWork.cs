using EquinityCommerceApp.Web.Models;
using EquinityCommerceApp.Web.Services.Base;
using Microsoft.Extensions.Options;

namespace EquinityCommerceApp.Web.Services
{
    public class UnitOfWork : IUnitOfWork
    {       

        public UnitOfWork(IOptions<ApiUrls> apiUrls, ILoggerFactory factory)
        {
            CategoryService = new CategoryHttpservice(apiUrls, factory);
            CoverTypeService = new CoverTypeHttpService(apiUrls, factory);
            ProductService = new ProductHttpservice(apiUrls, factory);
        }

        public IApiService<CategoryModel> CategoryService { get; private set; }

        public IApiService<CoverTypeModel> CoverTypeService { get; private set; }

        public IApiService<ProductModel> ProductService { get; private set; }
    }
}

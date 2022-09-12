using EquinityCommerceApp.Web.Services;
using Microsoft.Extensions.Options;

namespace EquinityCommerceApp.Web.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IOptions<ApiUrls> apiRuls;       

        public UnitOfWork(IOptions<ApiUrls> apiRuls, ILoggerFactory factory)
        {
            CategoryService = new CategoryHttpservice(apiRuls, factory);
            CoverTypeService = new CoverTypeHttpService(apiRuls, factory);
        }

        public IApiService<CategoryModel> CategoryService { get; private set; }

        public IApiService<CoverTypeModel> CoverTypeService { get; private set; }
    }
}

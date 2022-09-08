using AutoMapper;
using EquinityCommerceApp.Web.Entities;
using EquinityCommerceApp.Web.Models;

namespace EquinityCommerceApp.Web.Mapping
{
    public class CategoryModelToCategory : Profile
    {
        public CategoryModelToCategory()
        {
            this.CreateMap<CategoryModel, Category>().ReverseMap();
        }
    }
}

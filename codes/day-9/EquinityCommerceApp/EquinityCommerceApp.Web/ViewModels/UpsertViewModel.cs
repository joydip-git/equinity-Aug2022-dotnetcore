using EquinityCommerceApp.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace EquinityCommerceApp.Web.ViewModels
{
    public class UpsertViewModel
    {
        public ProductModel Product { get; set; } = new ProductModel();

        [Required]
        public IEnumerable<SelectListItem> CategoryList { get; set; } = new List<SelectListItem>();

        [Required]
        public IEnumerable<SelectListItem> CoverTypeyList { get; set; } = new List<SelectListItem>();
    }
}

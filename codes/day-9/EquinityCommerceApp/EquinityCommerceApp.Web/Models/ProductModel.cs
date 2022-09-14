using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EquinityCommerceApp.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal ListPrice { get; set; }

        [Required]
        [Display(Name = "Price=>1-50")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Price=>50-100")]
        public decimal PriceFifty { get; set; }

        [Required]
        [Display(Name = "Price=>100+")]
        public decimal PriceHundred { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "Category Id:")]
        public int? CategoryId { get; set; }

        [Required]
        [Display(Name = "Cover Type Id:")]
        public int? CoverTypeId { get; set; }

        [ValidateNever]
        public CategoryModel Category { get; set; }

        [ValidateNever]
        public CoverTypeModel CoverType { get; set; }
    }
}

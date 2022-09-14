using System.ComponentModel.DataAnnotations;

namespace EquinityCommerceApp.Web.Models
{
    public class ShoppingCart
    {
        public ProductModel Product { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Count { get; set; }
    }
}

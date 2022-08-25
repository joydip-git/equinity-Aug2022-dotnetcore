using System.ComponentModel.DataAnnotations;

namespace EquinityCommerceApp.Web.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1,100)]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}

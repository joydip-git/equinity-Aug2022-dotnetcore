using System.ComponentModel.DataAnnotations;

namespace EquinityCommerceApp.Web.Models
{
    public class CoverTypeModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

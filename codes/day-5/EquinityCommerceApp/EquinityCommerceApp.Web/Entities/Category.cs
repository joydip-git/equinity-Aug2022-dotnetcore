//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace EquinityCommerceApp.Web.Entities
{
    //[Table("categories")]
    public class Category
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Column("category_id")]
        public int CategoryId { get; set; }

        //[Column("category_name")]
        public string Name { get; set; }

        //[Column("display_order")]
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}

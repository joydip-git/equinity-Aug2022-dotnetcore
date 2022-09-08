using EquinityCommerceApp.Core.Entities.Base;

namespace EquinityCommerceApp.Core.Entities
{
    public class Category : Entity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}

using EquinityCommerceApp.Core.Entities.Base;

namespace EquinityCommerceApp.Core.Entities
{
    public class CoverType : Entity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        //public DateTime MyProperty { get; set; }
    }
}

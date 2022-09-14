using EquinityCommerceApp.Core.Entities.Base;

namespace EquinityCommerceApp.Core.Entities
{
    public class Product : Entity
    {
        public override int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Author { get; set; }
        public decimal ListPrice { get; set; }
        public decimal Price { get; set; }
        public decimal PriceFifty { get; set; }
        public decimal PriceHundred { get; set; }
        public string ImageUrl { get; set; }
        public int? CategoryId { get; set; }
        public int? CoverTypeId { get; set; }
        public Category? Category { get; set; }
        public CoverType? CoverType { get; set; }
    }
}

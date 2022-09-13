namespace EquinityCommerceApp.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
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
        public CategoryModel Category { get; set; }
        public CoverTypeModel CoverType { get; set; }
    }
}

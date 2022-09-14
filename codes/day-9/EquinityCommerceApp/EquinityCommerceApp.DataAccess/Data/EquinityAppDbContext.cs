using EquinityCommerceApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EquinityCommerceApp.DataAccess.Data
{
    public class EquinityAppDbContext : DbContext
    {
        //private readonly ILoggerFactory loggerFactory;
        public EquinityAppDbContext(DbContextOptions<EquinityAppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CoverType> CoverTypes { get; set; }
        public DbSet<Product> Products { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=joydip-pc;database=equinitydb;user id=sa;password=sqlserver2017");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildCategoryModel(modelBuilder);
            BuildCoverTypeModel(modelBuilder);
            BuildProductModel(modelBuilder);
        }

        private void BuildProductModel(ModelBuilder modelBuilder)
        {
            var productModelBuilder = modelBuilder.Entity<Product>();

            productModelBuilder.ToTable("products");
            productModelBuilder.HasKey(p => p.Id);

            productModelBuilder.Property<int>(p => p.Id)
                .HasColumnName("product_id")
                .HasColumnType("int")
                .IsRequired(true)
                .UseIdentityColumn(100, 1)
                .HasColumnOrder(0);

            productModelBuilder.Property<string>(p=>p.Title)
                .HasColumnName("product_name")
                .HasColumnType("varchar(50)")
                .IsRequired(true)
                .HasColumnOrder(1);

            productModelBuilder.Property<string>(p => p.Author)
               .HasColumnName("product_author")
               .HasColumnType("varchar(50)")
               .IsRequired(true)
               .HasColumnOrder(2);

            productModelBuilder.Property<string>(p => p.ISBN)
               .HasColumnName("product_isbn")
               .HasColumnType("varchar(10)")
               .IsRequired(true)
               .HasColumnOrder(3);

            productModelBuilder.Property<string>(p => p.Description)
               .HasColumnName("product_description")
               .HasColumnType("varchar(max)")
               .IsRequired(false)
               .HasColumnOrder(4);


            productModelBuilder.Property<decimal>(p=>p.ListPrice)
                .HasColumnName("product_list_price")
                .HasColumnType("decimal(18,2)")
                .IsRequired(true)
                .HasDefaultValue(0.0M)
                .HasColumnOrder(5);

            productModelBuilder.Property<decimal>(p => p.Price)
                .HasColumnName("product_price")
                .HasColumnType("decimal(18,2)")
                .IsRequired(true)
                .HasDefaultValue(0.0M)
                .HasColumnOrder(6);

            productModelBuilder.Property<decimal>(p => p.PriceFifty)
                .HasColumnName("product_fifty_price")
                .HasColumnType("decimal(18,2)")
                .IsRequired(true)
                .HasDefaultValue(0.0M)
                .HasColumnOrder(7);

            productModelBuilder.Property<decimal>(p => p.PriceHundred)
                .HasColumnName("product_hundred_price")
                .HasColumnType("decimal(18,2)")
                .IsRequired(true)
                .HasDefaultValue(0.0M)
                .HasColumnOrder(8);           

            productModelBuilder.Property<string>(p => p.ImageUrl)
                .HasColumnName("product_image_url")
                .HasColumnType("varchar(max)")
                .IsRequired(false)
                .HasColumnOrder(9);

            productModelBuilder.Property<int?>(p => p.CategoryId)
               .HasColumnName("category_id")
               .HasColumnType("int")
               .IsRequired(false)
               .HasColumnOrder(10);

            productModelBuilder.Property<int?>(p => p.CoverTypeId)
               .HasColumnName("cover_type_id")
               .HasColumnType("int")
               .IsRequired(false)
               .HasColumnOrder(11);

            productModelBuilder.HasOne(p => p.Category);
            productModelBuilder.HasOne(p => p.CoverType);
        }

        private static void BuildCategoryModel(ModelBuilder modelBuilder)
        {
            var categoryModelBuilder = modelBuilder.Entity<Category>();

            categoryModelBuilder.ToTable("categories");
            categoryModelBuilder.HasKey(c => c.Id);

            categoryModelBuilder.Property<int>(c => c.Id)
                .HasColumnName("category_id")
                .HasColumnType("int")
                .IsRequired(true)
                .UseIdentityColumn(100, 1)
                .HasColumnOrder(0);

            categoryModelBuilder.Property<string>(c => c.Name)
                .HasColumnName("category_name")
                .HasColumnType("varchar(50)")
                .IsRequired(true)
                .HasColumnOrder(1);

            categoryModelBuilder.Property<int>(c => c.DisplayOrder)
                .HasColumnName("category_display_order")
                .HasColumnType("int")
                .IsRequired(true)
                .HasDefaultValue(0)
                .HasColumnOrder(2);

            categoryModelBuilder.Property<DateTime>(c => c.CreatedDateTime)
                .HasColumnName("created_on")
                .HasColumnType("date")
                .HasDefaultValue(DateTime.Now)
                .IsRequired(true)
                .HasColumnOrder(3);
        }

        private static void BuildCoverTypeModel(ModelBuilder modelBuilder)
        {
            var coverTypeModelBuilder = modelBuilder.Entity<CoverType>();

            coverTypeModelBuilder.ToTable("covertypes");
            coverTypeModelBuilder.HasKey(c => c.Id);

            coverTypeModelBuilder.Property<int>(c => c.Id)
                .HasColumnName("covertype_id")
                .HasColumnType("int")
                .IsRequired(true)
                .UseIdentityColumn(100, 1)
                .HasColumnOrder(0);

            coverTypeModelBuilder.Property<string>(c => c.Name)
                .HasColumnName("covertype_name")
                .HasColumnType("varchar(50)")
                .IsRequired(true)
                .HasColumnOrder(1);
        }
    }
}

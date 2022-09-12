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
        //public DbSet<CoverType> CoverTypes { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=joydip-pc;database=equinitydb;user id=sa;password=sqlserver2017");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildCategoryModel(modelBuilder);
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
                       

            //coverTypeModelBuilder.Property<DateTime>(c => c.CreatedDateTime)
            //    .HasColumnName("created_on")
            //    .HasColumnType("date")
            //    .HasDefaultValue(DateTime.Now)
            //    .IsRequired(true)
            //    .HasColumnOrder(3);
        }
    }
}

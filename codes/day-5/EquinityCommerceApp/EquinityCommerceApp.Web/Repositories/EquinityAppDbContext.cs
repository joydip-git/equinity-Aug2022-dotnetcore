using EquinityCommerceApp.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquinityCommerceApp.Web.Repositories
{
    public class EquinityAppDbContext : DbContext
    {

        public EquinityAppDbContext(DbContextOptions<EquinityAppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=joydip-pc;database=equinitydb;user id=sa;password=sqlserver2017");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var categoryModelBuilder = modelBuilder.Entity<Category>();

            categoryModelBuilder.ToTable("categories");
            categoryModelBuilder.HasKey(c => c.CategoryId);

            categoryModelBuilder.Property<int>(c => c.CategoryId)
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
    }
}

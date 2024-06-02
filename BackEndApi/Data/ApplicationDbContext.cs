using BackEndApi.Data.SeedData;
using BackEndApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BackEndApi.Data
{
	public class ApplicationDbContext : IdentityDbContext<User>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}
		public ApplicationDbContext() { }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Size> Sizes { get; set; }
		public DbSet<ProductSku> ProductSkus { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }
		public DbSet<Order> Orders { get; set; }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Category>()
				.HasOne(c => c.Parent)
				.WithMany(c => c.SubCategories)
				.HasForeignKey(c => c.ParentId)
				.OnDelete(DeleteBehavior.Restrict);
			builder.Entity<ProductSku>()
				.HasOne(ps => ps.Size)
				.WithMany(s => s.ProductSkus)
				.HasForeignKey(ps => ps.SizeId)
				.OnDelete(DeleteBehavior.SetNull);

			builder.Seed();
		}
	}
}

using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Data.SeedData
{
    public static class ProductSeed
    {
        public static void SeedProduct(this ModelBuilder builder)
        {
            var aoThunCotton = new Product { Id = 1, Name = "Ao thun Cotton", CategoryId = 4, Color = "White", Price = 200000, Discontinued = false, UnitsInStock = 200 };
            var aoSoMiCafe = new Product { Id = 2, Name = "Ao So Mi Dai Tay Cafe", CategoryId = 5, Color = "Blue", Price = 429000, Discontinued = false, UnitsInStock = 200 };
            var quanShortsTheThao = new Product { Id = 3, Name = "Quan Shorts The Thao", CategoryId = 6, Color = "Black", Price = 159000, Discontinued = false, UnitsInStock = 200 };
            var quanShortsDaily = new Product { Id = 4, Name = "Quan Shorts Daily", CategoryId = 6, Color = "Green", Price = 229000, Discontinued = false, UnitsInStock = 200 };

            builder.Entity<Product>().HasData(aoThunCotton, aoSoMiCafe, quanShortsDaily, quanShortsTheThao);
        }

    }
}

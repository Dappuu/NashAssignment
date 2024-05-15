using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndApi.Data.SeedData
{
    public static class CategorySeed
    {
        public static void SeedCategory(this ModelBuilder builder)
        {
            var ao = new Category { Id = 1, Name = "Ao" };
            var quan = new Category { Id = 2, Name = "Quan" };
            var phuKien = new Category { Id = 3, Name = "Phu Kien" };
            var aoThun = new Category { Id = 4, Name = "Ao Thun", ParentId = ao.Id };
            var aoSoMi = new Category { Id = 5, Name = "Ao So Mi", ParentId = ao.Id };
            var quanShorts = new Category { Id = 6, Name = "Quan Shorts", ParentId = quan.Id };
            var quanJeans = new Category { Id = 7, Name = "Quan Jeans", ParentId = quan.Id };
            var tatVo = new Category { Id = 8, Name = "Tat/Vo", ParentId = phuKien.Id };
            var muNon = new Category { Id = 9, Name = "Mu/Non", ParentId = phuKien.Id };

            builder.Entity<Category>().HasData(ao, quan, phuKien, aoThun, aoSoMi, quanShorts, quanJeans, tatVo, muNon);
        }
    }
}

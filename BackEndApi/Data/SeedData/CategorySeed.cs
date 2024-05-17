using BackEndApi.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndApi.Data.SeedData
{
    public static class CategorySeed
    {
		public static void SeedCategory(this ModelBuilder builder)
        {
            var vong = new Category { Id = 1, Name = "Vòng" };
            var dayChuyen = new Category { Id = 2, Name = "Dây Chuyền" };
			var hoaTai = new Category { Id = 4, Name = "Hoa Tai" };
			var nhan = new Category { Id = 5, Name = "Nhẫn" };
			var vongDeoCharm = new Category { Id = 6, Name = "Vòng Đeo Charm", ParentId = vong.Id };
			var vongDayDa = new Category { Id = 7, Name = "Vòng Dây Da", ParentId = vong.Id };
			var vongDayRut = new Category { Id = 8, Name = "Vòng Dây Rút", ParentId = vong.Id };
			var dayChuyenCon = new Category { Id = 9, Name = "Dây Chuyền", ParentId = dayChuyen.Id };
			var matDayChuyen = new Category { Id = 10, Name = "Mặt Dây Chuyền", ParentId = dayChuyen.Id };
			var kieuTron = new Category { Id = 11, Name = "Kiểu Tròn", ParentId = hoaTai.Id };
			var kieuRoi = new Category { Id = 12, Name = "Kiểu Rơi", ParentId = hoaTai.Id };


			builder.Entity<Category>().HasData(vong, dayChuyen, hoaTai, nhan, vongDeoCharm, vongDayDa, vongDayRut, kieuTron, kieuRoi, dayChuyenCon, matDayChuyen);
        }
    }
}

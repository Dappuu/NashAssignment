using BackEndApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BackEndApi.Data.SeedData
{
	public static class ModelBuilderExtensions
	{
		public static void Seed(this ModelBuilder builder)
		{
			List<Category> categories = new()
			{
				new Category { Id = 1, Name = "Vòng" },
				new Category { Id = 2, Name = "Dây Chuyền" },
				new Category { Id = 3, Name = "Hoa Tai" },
				new Category { Id = 4, Name = "Nhẫn" },
				new Category { Id = 5, Name = "Vòng Đeo Charm", ParentId = 1 },
				new Category { Id = 6, Name = "Vòng Dây Da", ParentId = 1 },
				new Category { Id = 7, Name = "Vòng Dây Rút", ParentId = 1 },
				new Category { Id = 8, Name = "Dây Chuyền", ParentId = 2 },
				new Category { Id = 9, Name = "Kiểu Tròn", ParentId = 3 },
				new Category { Id = 10, Name = "Kiểu Rơi", ParentId = 3 },

			};
			builder.Entity<Category>().HasData(categories);


			List<Size> sizes = new()
			{
				new Size { Id = 1, Name = "16" },
				new Size { Id = 2, Name = "17" },
				new Size { Id = 3, Name = "18" },
				new Size { Id = 4, Name = "19" },
				new Size { Id = 5, Name = "41" },
				new Size { Id = 6, Name = "42" },
				new Size { Id = 7, Name = "43" },
				new Size { Id = 8, Name = "1" },
				new Size { Id = 9, Name = "2" },
				new Size { Id = 10, Name = "S1" },
				new Size { Id = 11, Name = "S2" }
			};
			builder.Entity<Size>().HasData(sizes);

			List<Product> products = new()
			{
				new Product { Id = 1, CategoryId = 5, Name = "Vòng Bạc Pandora Moments Khóa Hoa Hồng", Description = "Chinh phục cảm giác lãng mạn với chiếc vòng đeo tay dạng Snake Chain Pandora Moments Rose in Bloom của chúng tôi. Được chế tác từ bạc sterling, chiếc vòng tay này không chỉ là một phong cách trang sức mà còn là biểu hiện của tình yêu. Mẫu khóa hình hoa hồng được thiết kế tinh tế với những cánh hoa lớp lớp mang đến một chút dáng vẻ thanh lịch và ý nghĩa của hoa. Linh hoạt và phong cách, nó có thể chứa 16-18 món trang sức, được chia thành các threaders chức năng giúp bạn phân bố một cách hợp lý bộ sưu tập của mình. Hãy đeo nó như một lời nhắc nhở về tình yêu bạn có trong cuộc sống hoặc tặng nó cho người bạn quan tâm.", Material = "Bạc", Price = 2990000, ProductSkuName = "593211C00" },
				new Product { Id = 2, CategoryId = 5, Name = "Vòng Bạc Pandora Moments Khóa Ngôi Sao Đính Đá", Description = "Mang lại vẻ đẹp lấp lánh tự nhiên cho vẻ ngoài của bạn với Vòng đeo tay chuỗi rắn Pandora Moments Asymmetric Star Clasp. Được hoàn thiện thủ công bằng bạc sterling, móc cài hình ngôi sao của vòng tay được bao phủ bởi các pavé zirconia hình khối rõ ràng lấp lánh ở cả hai mặt. Nó có thể được đeo với tối đa 16-18 charm và clips mong muốn. Đeo theo một kiểu riêng để có vẻ ngoài đơn giản, tinh tế hoặc xếp nó với các thiết kế lấy cảm hứng từ thiên thể khác để có một diện mạo khác với thế giới này.", Material = "Bạc", Price = 3590000, ProductSkuName = "599639c01" },
				new Product { Id = 3, CategoryId = 6, Name = "Vòng Bạc Pandora Bọc Da Màu Xanh", Description = "Như một cuộc phiêu lưu dưới đáy đại dương và như một chuyến đi dạo giữa bầu trời đêm thật yên bình. Vòng đeo tay da dệt xanh Pandora Moments Round Clasp Blue Braided được đan từ những sợi dây da xanh đậm tinh tế, được kết thúc bằng khóa bạc sterling tròn và đầu bằng bạc sterling tinh tế. Phối cùng tối đa 9 món trang sức hoặc dây treo, chiếc vòng đeo tay này sẽ tôn lên vẻ đẹp độc đáo của các món trang sức yêu thích của bạn. Hãy để nó trở thành một tác phẩm nghệ thuật bất hủ trên cổ tay của bạn.", Material = "Da", Price = 2090000, ProductSkuName = "592790C01" },
				new Product { Id = 4, CategoryId = 6, Name = "Vòng Da Pandora Moments Mạ Vàng 14k Màu Đỏ", Description = "Thêm một chút sắc cạnh cho vẻ ngoài của bạn với chiếc vòng tay đan bằng chất liệu da sắc đỏ, kết hợp với phần nút gài mạ vàng 14K, một dòng kim loại hỗn hợp độc đáo được mạ vàng 14K. Hãy thử đeo những chiếc charm Pandora yêu thích của bạn theo một kiểu cách khác hơn cùng chiếc vòng da màu đỏ. Phong cách này hoàn toàn phù hợp với những bạn thích nổi bật giữa đám đông. Chiếc vòng tay đem đến cho bạn một vẻ ngoài đặc biệt và hiện đại, cho phép bạn thoải mái sáng tạo trong cách đeo. Bạn có thể kết hợp nó cùng với nhiều layer vòng tay và nhiều loại charm khác, cũng có thể đeo nó đơn lẻ như một tín vật bày tỏ.", Material = "Da", Price = 2390000, ProductSkuName = "568777C01" },
				new Product { Id = 5, CategoryId = 7, Name = "Vòng Bạc Pandora Lấp Lánh Khóa Trượt", Description = "Chọn lựa một phiên bản hiện đại của kiểu cổ điển với Vòng Sparkling Bars. Được thiết kế với các thanh hình hình lăng tròn có tám viên đá lấp lánh được đặt trong khung mở, vòng bạc sterling này cân bằng giữa các đường thẳng mượt mà với những đường cong tròn. Các thanh được kết nối thông minh bằng vòng nhả, cho phép tính linh hoạt và sự lấp lánh. Khóa có thể điều chỉnh được thiết kế với một dây treo có một viên đá lấp lánh ở đầu. Được thiết kế để có thể kết hợp sáng tạo với các mảng khác, vòng thanh lịch này có tiềm năng vô tận trong việc tạo kiểu.", Material = "Bạc", Price = 4790000, ProductSkuName = "593009C01" },
				new Product { Id = 6, CategoryId = 8, Name = "Dây Chuyền Bạc Disney x Pandora Mặt Dây Xe Bí Ngô", Description = "Theo đuổi lời kêu gọi của chiếc bóng với Dây Chuyền Disney Cinderella's Carriage Collier từ bộ sưu tập Disney x Pandora. Chiếc dây chuyền bạc sterling này có một mặt nạ tinh tế được lấy cảm hứng từ chiếc xe bí ngô phù thủy của Cinderella, với một viên đá hình lá cẩm màu xanh được bao quanh bởi các chi tiết mở xoắn. Những viên đá cubic zirconia nhỏ lấp lánh trên bánh xe và thân bí ngô. Mặt nạ được cố định trên dây chuyền và có thể điều chỉnh được thành ba chiều dài. Kết hợp nó với đôi bông tai nút tương ứng để tạo nên một diện mạo cao cấp lấy cảm hứng từ Cinderella.", Material = "Bạc", Price = 4790000, ProductSkuName = "393057C01" },
			};
			builder.Entity<Product>().HasData(products);

			List<ProductSku> productSkus = new()
			{
				new ProductSku { Id = 1, SizeId = 1, UnitsInStock = 100, ProductId = 1},
				new ProductSku { Id = 2, SizeId = 2, UnitsInStock = 100, ProductId = 1 },
				new ProductSku { Id = 3, SizeId = 3, UnitsInStock = 100, ProductId = 1 },
				new ProductSku { Id = 4, SizeId = 4, UnitsInStock = 100, ProductId = 2 },
				new ProductSku { Id = 5, SizeId = 10, UnitsInStock = 100, ProductId = 3 },
				new ProductSku { Id = 6, SizeId = 11, UnitsInStock = 100, ProductId = 3 },
				new ProductSku { Id = 8, SizeId = 8, UnitsInStock = 100, ProductId = 4 },
				new ProductSku { Id = 7, SizeId = 1, UnitsInStock = 100, ProductId = 5 },

			};

			builder.Entity<ProductSku>().HasData(productSkus);


			List<IdentityRole> roles = new List<IdentityRole>
			{
				new IdentityRole
				{
					Name = "Admin",
					NormalizedName = "ADMIN",

				},
				new IdentityRole
				{
					Name = "User",
					NormalizedName = "USER",
				},
			};
			builder.Entity<IdentityRole>().HasData(roles);
		}
	}
}

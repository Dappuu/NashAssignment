using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEnd_Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserID",
                        column: x => x.UserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductSkuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "Decimal(3,2)", nullable: true),
                    Price = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    UnitsSold = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "Decimal(3,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSkus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    UnitsInStock = table.Column<int>(type: "int", nullable: false),
                    UnitsSold = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSkus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductSkus_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSkus_Sizes_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Sizes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ProductSkuId = table.Column<int>(type: "int", nullable: true),
                    OrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_ProductSkus_ProductSkuId",
                        column: x => x.ProductSkuId,
                        principalTable: "ProductSkus",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "196af072-1379-415d-bfa1-a2ff3e485f43", null, "Admin", "ADMIN" },
                    { "b4e8cf64-e48a-4745-a3e5-a8171371cc37", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, "", null, "Vòng", null },
                    { 2, "", null, "Dây Chuyền", null },
                    { 3, "", null, "Hoa Tai", null },
                    { 4, "", null, "Nhẫn", null }
                });

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "16" },
                    { 2, "17" },
                    { 3, "18" },
                    { 4, "19" },
                    { 5, "41" },
                    { 6, "42" },
                    { 7, "43" },
                    { 8, "1" },
                    { 9, "2" },
                    { 10, "S1" },
                    { 11, "S2" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "ParentId" },
                values: new object[,]
                {
                    { 5, "", null, "Vòng Đeo Charm", 1 },
                    { 6, "", null, "Vòng Dây Da", 1 },
                    { 7, "", null, "Vòng Dây Rút", 1 },
                    { 8, "", null, "Dây Chuyền", 2 },
                    { 9, "", null, "Kiểu Tròn", 3 },
                    { 10, "", null, "Kiểu Rơi", 3 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "CategoryId", "CreatedDate", "Description", "Discount", "ImageUrl", "Material", "Name", "Price", "ProductSkuName", "Rating", "UnitsInStock", "UnitsSold", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, true, 5, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1206), "Chinh phục cảm giác lãng mạn với chiếc vòng đeo tay dạng Snake Chain Pandora Moments Rose in Bloom của chúng tôi. Được chế tác từ bạc sterling, chiếc vòng tay này không chỉ là một phong cách trang sức mà còn là biểu hiện của tình yêu. Mẫu khóa hình hoa hồng được thiết kế tinh tế với những cánh hoa lớp lớp mang đến một chút dáng vẻ thanh lịch và ý nghĩa của hoa. Linh hoạt và phong cách, nó có thể chứa 16-18 món trang sức, được chia thành các threaders chức năng giúp bạn phân bố một cách hợp lý bộ sưu tập của mình. Hãy đeo nó như một lời nhắc nhở về tình yêu bạn có trong cuộc sống hoặc tặng nó cho người bạn quan tâm.", 0, "", "Bạc", "Vòng Bạc Pandora Moments Khóa Hoa Hồng", 2990000m, "593211C00", null, 0, 0, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1217) },
                    { 2, true, 5, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1225), "Mang lại vẻ đẹp lấp lánh tự nhiên cho vẻ ngoài của bạn với Vòng đeo tay chuỗi rắn Pandora Moments Asymmetric Star Clasp. Được hoàn thiện thủ công bằng bạc sterling, móc cài hình ngôi sao của vòng tay được bao phủ bởi các pavé zirconia hình khối rõ ràng lấp lánh ở cả hai mặt. Nó có thể được đeo với tối đa 16-18 charm và clips mong muốn. Đeo theo một kiểu riêng để có vẻ ngoài đơn giản, tinh tế hoặc xếp nó với các thiết kế lấy cảm hứng từ thiên thể khác để có một diện mạo khác với thế giới này.", 0, "", "Bạc", "Vòng Bạc Pandora Moments Khóa Ngôi Sao Đính Đá", 3590000m, "599639c01", null, 0, 0, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1226) },
                    { 3, true, 6, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1228), "Như một cuộc phiêu lưu dưới đáy đại dương và như một chuyến đi dạo giữa bầu trời đêm thật yên bình. Vòng đeo tay da dệt xanh Pandora Moments Round Clasp Blue Braided được đan từ những sợi dây da xanh đậm tinh tế, được kết thúc bằng khóa bạc sterling tròn và đầu bằng bạc sterling tinh tế. Phối cùng tối đa 9 món trang sức hoặc dây treo, chiếc vòng đeo tay này sẽ tôn lên vẻ đẹp độc đáo của các món trang sức yêu thích của bạn. Hãy để nó trở thành một tác phẩm nghệ thuật bất hủ trên cổ tay của bạn.", 0, "", "Da", "Vòng Bạc Pandora Bọc Da Màu Xanh", 2090000m, "592790C01", null, 0, 0, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1228) },
                    { 4, true, 6, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1230), "Thêm một chút sắc cạnh cho vẻ ngoài của bạn với chiếc vòng tay đan bằng chất liệu da sắc đỏ, kết hợp với phần nút gài mạ vàng 14K, một dòng kim loại hỗn hợp độc đáo được mạ vàng 14K. Hãy thử đeo những chiếc charm Pandora yêu thích của bạn theo một kiểu cách khác hơn cùng chiếc vòng da màu đỏ. Phong cách này hoàn toàn phù hợp với những bạn thích nổi bật giữa đám đông. Chiếc vòng tay đem đến cho bạn một vẻ ngoài đặc biệt và hiện đại, cho phép bạn thoải mái sáng tạo trong cách đeo. Bạn có thể kết hợp nó cùng với nhiều layer vòng tay và nhiều loại charm khác, cũng có thể đeo nó đơn lẻ như một tín vật bày tỏ.", 0, "", "Da", "Vòng Da Pandora Moments Mạ Vàng 14k Màu Đỏ", 2390000m, "568777C01", null, 0, 0, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1230) },
                    { 5, true, 7, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1232), "Chọn lựa một phiên bản hiện đại của kiểu cổ điển với Vòng Sparkling Bars. Được thiết kế với các thanh hình hình lăng tròn có tám viên đá lấp lánh được đặt trong khung mở, vòng bạc sterling này cân bằng giữa các đường thẳng mượt mà với những đường cong tròn. Các thanh được kết nối thông minh bằng vòng nhả, cho phép tính linh hoạt và sự lấp lánh. Khóa có thể điều chỉnh được thiết kế với một dây treo có một viên đá lấp lánh ở đầu. Được thiết kế để có thể kết hợp sáng tạo với các mảng khác, vòng thanh lịch này có tiềm năng vô tận trong việc tạo kiểu.", 0, "", "Bạc", "Vòng Bạc Pandora Lấp Lánh Khóa Trượt", 4790000m, "593009C01", null, 0, 0, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1232) },
                    { 6, true, 8, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1235), "Theo đuổi lời kêu gọi của chiếc bóng với Dây Chuyền Disney Cinderella's Carriage Collier từ bộ sưu tập Disney x Pandora. Chiếc dây chuyền bạc sterling này có một mặt nạ tinh tế được lấy cảm hứng từ chiếc xe bí ngô phù thủy của Cinderella, với một viên đá hình lá cẩm màu xanh được bao quanh bởi các chi tiết mở xoắn. Những viên đá cubic zirconia nhỏ lấp lánh trên bánh xe và thân bí ngô. Mặt nạ được cố định trên dây chuyền và có thể điều chỉnh được thành ba chiều dài. Kết hợp nó với đôi bông tai nút tương ứng để tạo nên một diện mạo cao cấp lấy cảm hứng từ Cinderella.", 0, "", "Bạc", "Dây Chuyền Bạc Disney x Pandora Mặt Dây Xe Bí Ngô", 4790000m, "393057C01", null, 0, 0, new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1235) }
                });

            migrationBuilder.InsertData(
                table: "ProductSkus",
                columns: new[] { "Id", "ProductId", "SizeId", "UnitsInStock", "UnitsSold" },
                values: new object[,]
                {
                    { 1, 1, 1, 100, 0 },
                    { 2, 1, 2, 100, 0 },
                    { 3, 1, 3, 100, 0 },
                    { 4, 2, 4, 100, 0 },
                    { 5, 3, 10, 100, 0 },
                    { 6, 3, 11, 100, 0 },
                    { 7, 5, 1, 100, 0 },
                    { 8, 4, 8, 100, 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductSkuId",
                table: "OrderDetails",
                column: "ProductSkuId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserID",
                table: "Orders",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSkus_ProductId",
                table: "ProductSkus",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSkus_SizeId",
                table: "ProductSkus",
                column: "SizeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductSkus");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

﻿// <auto-generated />
using System;
using BackEndApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BackEndApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240521034803_Add_rating_field_for_Product")]
    partial class Add_rating_field_for_Product
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BackEndApi.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Vòng"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dây Chuyền"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hoa Tai"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nhẫn"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Vòng Đeo Charm",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 6,
                            Name = "Vòng Dây Da",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 7,
                            Name = "Vòng Dây Rút",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 8,
                            Name = "Dây Chuyền",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 9,
                            Name = "Kiểu Tròn",
                            ParentId = 3
                        },
                        new
                        {
                            Id = 10,
                            Name = "Kiểu Rơi",
                            ParentId = 3
                        });
                });

            modelBuilder.Entity("BackEndApi.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<decimal>("Rating")
                        .HasColumnType("Decimal(1, 1)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserId1")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId1");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("BackEndApi.Models.Image", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("BackEndApi.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Total")
                        .HasColumnType("Decimal(12, 2)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BackEndApi.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal(12, 2)");

                    b.Property<int?>("ProductSkuId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductSkuId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("BackEndApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Decimal(12, 2)");

                    b.Property<string>("ProductSkuName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Rating")
                        .HasColumnType("Decimal(1, 1)");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.Property<int>("UnitsSold")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            CategoryId = 5,
                            CreatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3704),
                            Description = "Chinh phục cảm giác lãng mạn với chiếc vòng đeo tay dạng Snake Chain Pandora Moments Rose in Bloom của chúng tôi. Được chế tác từ bạc sterling, chiếc vòng tay này không chỉ là một phong cách trang sức mà còn là biểu hiện của tình yêu. Mẫu khóa hình hoa hồng được thiết kế tinh tế với những cánh hoa lớp lớp mang đến một chút dáng vẻ thanh lịch và ý nghĩa của hoa. Linh hoạt và phong cách, nó có thể chứa 16-18 món trang sức, được chia thành các threaders chức năng giúp bạn phân bố một cách hợp lý bộ sưu tập của mình. Hãy đeo nó như một lời nhắc nhở về tình yêu bạn có trong cuộc sống hoặc tặng nó cho người bạn quan tâm.",
                            Discount = 0,
                            Material = "Bạc",
                            Name = "Vòng Bạc Pandora Moments Khóa Hoa Hồng",
                            Price = 2990000m,
                            ProductSkuName = "593211C00",
                            UnitsInStock = 0,
                            UnitsSold = 0,
                            UpdatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3714)
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            CategoryId = 5,
                            CreatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3722),
                            Description = "Mang lại vẻ đẹp lấp lánh tự nhiên cho vẻ ngoài của bạn với Vòng đeo tay chuỗi rắn Pandora Moments Asymmetric Star Clasp. Được hoàn thiện thủ công bằng bạc sterling, móc cài hình ngôi sao của vòng tay được bao phủ bởi các pavé zirconia hình khối rõ ràng lấp lánh ở cả hai mặt. Nó có thể được đeo với tối đa 16-18 charm và clips mong muốn. Đeo theo một kiểu riêng để có vẻ ngoài đơn giản, tinh tế hoặc xếp nó với các thiết kế lấy cảm hứng từ thiên thể khác để có một diện mạo khác với thế giới này.",
                            Discount = 0,
                            Material = "Bạc",
                            Name = "Vòng Bạc Pandora Moments Khóa Ngôi Sao Đính Đá",
                            Price = 3590000m,
                            ProductSkuName = "599639c01",
                            UnitsInStock = 0,
                            UnitsSold = 0,
                            UpdatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3723)
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            CategoryId = 6,
                            CreatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3725),
                            Description = "Như một cuộc phiêu lưu dưới đáy đại dương và như một chuyến đi dạo giữa bầu trời đêm thật yên bình. Vòng đeo tay da dệt xanh Pandora Moments Round Clasp Blue Braided được đan từ những sợi dây da xanh đậm tinh tế, được kết thúc bằng khóa bạc sterling tròn và đầu bằng bạc sterling tinh tế. Phối cùng tối đa 9 món trang sức hoặc dây treo, chiếc vòng đeo tay này sẽ tôn lên vẻ đẹp độc đáo của các món trang sức yêu thích của bạn. Hãy để nó trở thành một tác phẩm nghệ thuật bất hủ trên cổ tay của bạn.",
                            Discount = 0,
                            Material = "Da",
                            Name = "Vòng Bạc Pandora Bọc Da Màu Xanh",
                            Price = 2090000m,
                            ProductSkuName = "592790C01",
                            UnitsInStock = 0,
                            UnitsSold = 0,
                            UpdatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3725)
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            CategoryId = 6,
                            CreatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3727),
                            Description = "Thêm một chút sắc cạnh cho vẻ ngoài của bạn với chiếc vòng tay đan bằng chất liệu da sắc đỏ, kết hợp với phần nút gài mạ vàng 14K, một dòng kim loại hỗn hợp độc đáo được mạ vàng 14K. Hãy thử đeo những chiếc charm Pandora yêu thích của bạn theo một kiểu cách khác hơn cùng chiếc vòng da màu đỏ. Phong cách này hoàn toàn phù hợp với những bạn thích nổi bật giữa đám đông. Chiếc vòng tay đem đến cho bạn một vẻ ngoài đặc biệt và hiện đại, cho phép bạn thoải mái sáng tạo trong cách đeo. Bạn có thể kết hợp nó cùng với nhiều layer vòng tay và nhiều loại charm khác, cũng có thể đeo nó đơn lẻ như một tín vật bày tỏ.",
                            Discount = 0,
                            Material = "Da",
                            Name = "Vòng Da Pandora Moments Mạ Vàng 14k Màu Đỏ",
                            Price = 2390000m,
                            ProductSkuName = "568777C01",
                            UnitsInStock = 0,
                            UnitsSold = 0,
                            UpdatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3727)
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            CategoryId = 7,
                            CreatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3729),
                            Description = "Chọn lựa một phiên bản hiện đại của kiểu cổ điển với Vòng Sparkling Bars. Được thiết kế với các thanh hình hình lăng tròn có tám viên đá lấp lánh được đặt trong khung mở, vòng bạc sterling này cân bằng giữa các đường thẳng mượt mà với những đường cong tròn. Các thanh được kết nối thông minh bằng vòng nhả, cho phép tính linh hoạt và sự lấp lánh. Khóa có thể điều chỉnh được thiết kế với một dây treo có một viên đá lấp lánh ở đầu. Được thiết kế để có thể kết hợp sáng tạo với các mảng khác, vòng thanh lịch này có tiềm năng vô tận trong việc tạo kiểu.",
                            Discount = 0,
                            Material = "Bạc",
                            Name = "Vòng Bạc Pandora Lấp Lánh Khóa Trượt",
                            Price = 4790000m,
                            ProductSkuName = "593009C01",
                            UnitsInStock = 0,
                            UnitsSold = 0,
                            UpdatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3729)
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            CategoryId = 8,
                            CreatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3732),
                            Description = "Theo đuổi lời kêu gọi của chiếc bóng với Dây Chuyền Disney Cinderella's Carriage Collier từ bộ sưu tập Disney x Pandora. Chiếc dây chuyền bạc sterling này có một mặt nạ tinh tế được lấy cảm hứng từ chiếc xe bí ngô phù thủy của Cinderella, với một viên đá hình lá cẩm màu xanh được bao quanh bởi các chi tiết mở xoắn. Những viên đá cubic zirconia nhỏ lấp lánh trên bánh xe và thân bí ngô. Mặt nạ được cố định trên dây chuyền và có thể điều chỉnh được thành ba chiều dài. Kết hợp nó với đôi bông tai nút tương ứng để tạo nên một diện mạo cao cấp lấy cảm hứng từ Cinderella.",
                            Discount = 0,
                            Material = "Bạc",
                            Name = "Dây Chuyền Bạc Disney x Pandora Mặt Dây Xe Bí Ngô",
                            Price = 4790000m,
                            ProductSkuName = "393057C01",
                            UnitsInStock = 0,
                            UnitsSold = 0,
                            UpdatedDate = new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3732)
                        });
                });

            modelBuilder.Entity("BackEndApi.Models.ProductSku", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("SizeId")
                        .HasColumnType("int");

                    b.Property<int>("UnitsInStock")
                        .HasColumnType("int");

                    b.Property<int>("UnitsSold")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SizeId");

                    b.ToTable("ProductSkus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            SizeId = 1,
                            UnitsInStock = 100,
                            UnitsSold = 0
                        },
                        new
                        {
                            Id = 2,
                            ProductId = 1,
                            SizeId = 2,
                            UnitsInStock = 100,
                            UnitsSold = 0
                        },
                        new
                        {
                            Id = 3,
                            ProductId = 1,
                            SizeId = 3,
                            UnitsInStock = 100,
                            UnitsSold = 0
                        },
                        new
                        {
                            Id = 4,
                            ProductId = 2,
                            SizeId = 4,
                            UnitsInStock = 100,
                            UnitsSold = 0
                        },
                        new
                        {
                            Id = 5,
                            ProductId = 3,
                            SizeId = 10,
                            UnitsInStock = 100,
                            UnitsSold = 0
                        },
                        new
                        {
                            Id = 6,
                            ProductId = 3,
                            SizeId = 11,
                            UnitsInStock = 100,
                            UnitsSold = 0
                        },
                        new
                        {
                            Id = 8,
                            ProductId = 4,
                            SizeId = 8,
                            UnitsInStock = 100,
                            UnitsSold = 0
                        },
                        new
                        {
                            Id = 7,
                            ProductId = 5,
                            SizeId = 1,
                            UnitsInStock = 100,
                            UnitsSold = 0
                        });
                });

            modelBuilder.Entity("BackEndApi.Models.Size", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sizes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "16"
                        },
                        new
                        {
                            Id = 2,
                            Name = "17"
                        },
                        new
                        {
                            Id = 3,
                            Name = "18"
                        },
                        new
                        {
                            Id = 4,
                            Name = "19"
                        },
                        new
                        {
                            Id = 5,
                            Name = "41"
                        },
                        new
                        {
                            Id = 6,
                            Name = "42"
                        },
                        new
                        {
                            Id = 7,
                            Name = "43"
                        },
                        new
                        {
                            Id = 8,
                            Name = "1"
                        },
                        new
                        {
                            Id = 9,
                            Name = "2"
                        },
                        new
                        {
                            Id = 10,
                            Name = "S1"
                        },
                        new
                        {
                            Id = 11,
                            Name = "S2"
                        });
                });

            modelBuilder.Entity("BackEndApi.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "19931b6b-40e6-400f-8ec2-3d2f3e0c9d99",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "74b0f1a5-662f-4ad0-827e-f1456742ead4",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BackEndApi.Models.Category", b =>
                {
                    b.HasOne("BackEndApi.Models.Category", "Parent")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("BackEndApi.Models.Comment", b =>
                {
                    b.HasOne("BackEndApi.Models.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndApi.Models.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId1");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BackEndApi.Models.Image", b =>
                {
                    b.HasOne("BackEndApi.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("BackEndApi.Models.Order", b =>
                {
                    b.HasOne("BackEndApi.Models.User", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("BackEndApi.Models.OrderDetail", b =>
                {
                    b.HasOne("BackEndApi.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndApi.Models.ProductSku", "ProductSku")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductSkuId");

                    b.Navigation("Order");

                    b.Navigation("ProductSku");
                });

            modelBuilder.Entity("BackEndApi.Models.Product", b =>
                {
                    b.HasOne("BackEndApi.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BackEndApi.Models.ProductSku", b =>
                {
                    b.HasOne("BackEndApi.Models.Product", "Product")
                        .WithMany("productSkus")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndApi.Models.Size", "Size")
                        .WithMany("ProductSkus")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BackEndApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BackEndApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BackEndApi.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEndApi.Models.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("SubCategories");
                });

            modelBuilder.Entity("BackEndApi.Models.Order", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BackEndApi.Models.Product", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Images");

                    b.Navigation("productSkus");
                });

            modelBuilder.Entity("BackEndApi.Models.ProductSku", b =>
                {
                    b.Navigation("OrderDetails");
                });

            modelBuilder.Entity("BackEndApi.Models.Size", b =>
                {
                    b.Navigation("ProductSkus");
                });

            modelBuilder.Entity("BackEndApi.Models.User", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}

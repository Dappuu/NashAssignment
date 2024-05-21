using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEndApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_rating_field_for_Product : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "02337235-2628-4558-befb-1a3232ff6c19");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9ca9a05-e432-40d3-b72b-4b1b05192275");

            migrationBuilder.AddColumn<decimal>(
                name: "Rating",
                table: "Products",
                type: "Decimal(1,1)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19931b6b-40e6-400f-8ec2-3d2f3e0c9d99", null, "Admin", "ADMIN" },
                    { "74b0f1a5-662f-4ad0-827e-f1456742ead4", null, "user", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Rating", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3704), null, new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3714) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Rating", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3722), null, new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3723) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Rating", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3725), null, new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3725) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "Rating", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3727), null, new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3727) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "Rating", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3729), null, new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3729) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "Rating", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3732), null, new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3732) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19931b6b-40e6-400f-8ec2-3d2f3e0c9d99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74b0f1a5-662f-4ad0-827e-f1456742ead4");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "02337235-2628-4558-befb-1a3232ff6c19", null, "Admin", "ADMIN" },
                    { "b9ca9a05-e432-40d3-b72b-4b1b05192275", null, "user", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6679), new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6691) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6699), new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6701) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6706), new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6708) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6712), new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6714) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6717), new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6719) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6725), new DateTime(2024, 5, 19, 12, 17, 21, 350, DateTimeKind.Local).AddTicks(6727) });
        }
    }
}

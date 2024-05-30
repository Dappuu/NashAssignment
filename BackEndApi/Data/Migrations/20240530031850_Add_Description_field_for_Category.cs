using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEndApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Description_field_for_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12a68676-cba1-46e8-ba76-3d4a0e9c7e7a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3907436e-7fcc-4fa3-aa68-cc55c5efbce1");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "14cd7ea0-516f-42c2-b589-b6275f5dd292", null, "Admin", "ADMIN" },
                    { "722daf09-b91d-4a53-b188-9e79c2e78b35", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "Description",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5167), new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5180) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5193), new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5194) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5197), new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5197) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5200), new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5200) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5203), new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5203) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5207), new DateTime(2024, 5, 30, 10, 18, 48, 965, DateTimeKind.Local).AddTicks(5207) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "14cd7ea0-516f-42c2-b589-b6275f5dd292");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "722daf09-b91d-4a53-b188-9e79c2e78b35");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12a68676-cba1-46e8-ba76-3d4a0e9c7e7a", null, "User", "USER" },
                    { "3907436e-7fcc-4fa3-aa68-cc55c5efbce1", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8940), new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8952) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8962), new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8962) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8969), new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8969) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8971), new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8972) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8974), new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8975) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8979), new DateTime(2024, 5, 22, 22, 50, 35, 394, DateTimeKind.Local).AddTicks(8979) });
        }
    }
}

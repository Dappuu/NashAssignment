using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEnd_Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Delete_Image_In_Category : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "196af072-1379-415d-bfa1-a2ff3e485f43");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b4e8cf64-e48a-4745-a3e5-a8171371cc37");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Categories");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "404adf58-5ab6-48cf-883b-4f7e2ccc415b", null, "Admin", "ADMIN" },
                    { "a0ca9ec3-25d7-48bc-a500-2a59b9fde9fe", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3368), new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3379) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3389), new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3389) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3391), new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3391) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3393), new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3394) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3395), new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3396) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3398), new DateTime(2024, 6, 2, 11, 0, 29, 968, DateTimeKind.Local).AddTicks(3399) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "404adf58-5ab6-48cf-883b-4f7e2ccc415b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0ca9ec3-25d7-48bc-a500-2a59b9fde9fe");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "196af072-1379-415d-bfa1-a2ff3e485f43", null, "Admin", "ADMIN" },
                    { "b4e8cf64-e48a-4745-a3e5-a8171371cc37", null, "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImageUrl",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1206), new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1217) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1225), new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1226) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1228), new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1228) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1230), new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1230) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1232), new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1232) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1235), new DateTime(2024, 6, 2, 10, 46, 0, 868, DateTimeKind.Local).AddTicks(1235) });
        }
    }
}

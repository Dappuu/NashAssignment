using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BackEndApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class modify_userId_in_Comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId1",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19931b6b-40e6-400f-8ec2-3d2f3e0c9d99");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "74b0f1a5-662f-4ad0-827e-f1456742ead4");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Comments");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "13f35a9b-55fa-4426-ad05-0167ce8b85a1", null, "user", "USER" },
                    { "b3c8f0b0-27bf-4609-9c50-3c6184a48d4a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3535), new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3549) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3557), new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3558) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3560), new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3562), new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3562) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3564), new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3564) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3567), new DateTime(2024, 5, 21, 16, 27, 4, 400, DateTimeKind.Local).AddTicks(3567) });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "13f35a9b-55fa-4426-ad05-0167ce8b85a1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3c8f0b0-27bf-4609-9c50-3c6184a48d4a");

            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Comments",
                type: "nvarchar(450)",
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
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3704), new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3714) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3722), new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3723) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3725), new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3725) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3727), new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3727) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3729), new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3729) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3732), new DateTime(2024, 5, 21, 10, 48, 2, 34, DateTimeKind.Local).AddTicks(3732) });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId1",
                table: "Comments",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId1",
                table: "Comments",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

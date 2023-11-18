using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MinFin.Web.Migrations
{
    /// <inheritdoc />
    public partial class Inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportSeries = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportType = table.Column<byte>(type: "tinyint", nullable: false),
                    SignType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreateDt", "Email", "FirstName", "IsDeleted", "MiddleName", "PassportNumber", "PassportSeries", "PassportType", "Password", "PasswordKey", "SignType", "Surname", "UpdateDt" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 17, 19, 5, 39, 313, DateTimeKind.Local).AddTicks(1019), "dima.Kambur.2001@mail.ru", "Dmitry", false, "Sergeevich", "123123123", "12321312321", (byte)0, new byte[] { 180, 77, 190, 185, 8, 233, 97, 149, 194, 48, 44, 165, 129, 45, 112, 33, 66, 255, 236, 164, 200, 185, 180, 95, 32, 72, 115, 150, 13, 162, 158, 76, 172, 210, 134, 7, 160, 92, 252, 86, 143, 175, 94, 97, 199, 235, 76, 155, 50, 38, 168, 195, 121, 197, 125, 82, 85, 135, 47, 196, 196, 254, 48, 247 }, new byte[] { 141, 97, 198, 117, 24, 86, 132, 208, 112, 245, 35, 164, 157, 141, 108, 136, 161, 12, 96, 54, 172, 57, 90, 57, 43, 229, 79, 190, 78, 155, 229, 241, 85, 149, 239, 235, 55, 176, 254, 0, 73, 160, 12, 209, 68, 153, 37, 79, 133, 82, 9, 7, 206, 163, 229, 187, 136, 241, 196, 30, 105, 167, 93, 42, 226, 43, 55, 148, 17, 18, 148, 166, 233, 89, 206, 123, 245, 24, 62, 88, 16, 87, 2, 148, 160, 156, 91, 219, 185, 213, 136, 130, 86, 232, 173, 250, 230, 252, 243, 130, 40, 74, 56, 160, 236, 67, 254, 169, 28, 37, 192, 26, 166, 253, 137, 25, 91, 237, 168, 217, 10, 233, 62, 95, 212, 61, 183, 205 }, (byte)0, "Kambur", new DateTime(2023, 11, 17, 19, 5, 39, 313, DateTimeKind.Local).AddTicks(1065) },
                    { 2, new DateTime(2023, 11, 17, 19, 5, 39, 313, DateTimeKind.Local).AddTicks(1071), "what.is.love.kirilenko@mail.ru", "Vladislav", false, "", "123123123", "12321312321", (byte)1, new byte[] { 180, 77, 190, 185, 8, 233, 97, 149, 194, 48, 44, 165, 129, 45, 112, 33, 66, 255, 236, 164, 200, 185, 180, 95, 32, 72, 115, 150, 13, 162, 158, 76, 172, 210, 134, 7, 160, 92, 252, 86, 143, 175, 94, 97, 199, 235, 76, 155, 50, 38, 168, 195, 121, 197, 125, 82, 85, 135, 47, 196, 196, 254, 48, 247 }, new byte[] { 141, 97, 198, 117, 24, 86, 132, 208, 112, 245, 35, 164, 157, 141, 108, 136, 161, 12, 96, 54, 172, 57, 90, 57, 43, 229, 79, 190, 78, 155, 229, 241, 85, 149, 239, 235, 55, 176, 254, 0, 73, 160, 12, 209, 68, 153, 37, 79, 133, 82, 9, 7, 206, 163, 229, 187, 136, 241, 196, 30, 105, 167, 93, 42, 226, 43, 55, 148, 17, 18, 148, 166, 233, 89, 206, 123, 245, 24, 62, 88, 16, 87, 2, 148, 160, 156, 91, 219, 185, 213, 136, 130, 86, 232, 173, 250, 230, 252, 243, 130, 40, 74, 56, 160, 236, 67, 254, 169, 28, 37, 192, 26, 166, 253, 137, 25, 91, 237, 168, 217, 10, 233, 62, 95, 212, 61, 183, 205 }, (byte)1, "Kirilenko", new DateTime(2023, 11, 17, 19, 5, 39, 313, DateTimeKind.Local).AddTicks(1072) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

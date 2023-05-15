using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsUA.API.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EdittedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "AuthorName", "EdittedAt", "HotStatus", "Information", "PhotoUrl", "PublishedAt", "Status", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 1, "Author name 1", null, "Basic", "Information 1", null, new DateTime(2023, 5, 15, 16, 3, 49, 175, DateTimeKind.Local).AddTicks(6640), "InProcess", "SubTitle 1", "Title 1" },
                    { 2, "Author name 2", null, "Hot", "Information 2", null, new DateTime(2023, 5, 15, 16, 3, 49, 175, DateTimeKind.Local).AddTicks(6711), "InProcess", "SubTitle 2", "Title 2" },
                    { 3, "Author name 3", null, "Basic", "Information 3", null, new DateTime(2023, 5, 15, 16, 3, 49, 175, DateTimeKind.Local).AddTicks(6715), "InProcess", "SubTitle 3", "Title 3" },
                    { 4, "Author name 4", null, "Basic", "Information 4", null, new DateTime(2023, 5, 15, 16, 3, 49, 175, DateTimeKind.Local).AddTicks(6720), "InProcess", "SubTitle 4", "Title 4" },
                    { 5, "Author name 5", null, "Basic", "Information 5", null, new DateTime(2023, 5, 15, 16, 3, 49, 175, DateTimeKind.Local).AddTicks(6724), "InProcess", "SubTitle 5", "Title 5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");
        }
    }
}

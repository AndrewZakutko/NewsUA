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
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsHot = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EdittedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelegramBotSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelegramBotSettings", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "AuthorName", "EdittedAt", "Information", "IsHot", "PublishedAt", "Status", "SubTitle", "Title", "Type" },
                values: new object[,]
                {
                    { 1, "Author name 1", null, "Information 1", false, new DateTime(2023, 5, 24, 10, 37, 3, 53, DateTimeKind.Local).AddTicks(4479), "InProcess", "SubTitle 1", "Title 1", "Entertainment" },
                    { 2, "Author name 2", null, "Information 2", true, new DateTime(2023, 5, 24, 10, 37, 3, 53, DateTimeKind.Local).AddTicks(4537), "InProcess", "SubTitle 2", "Title 2", "Entertainment" },
                    { 3, "Author name 3", null, "Information 3", false, new DateTime(2023, 5, 24, 10, 37, 3, 53, DateTimeKind.Local).AddTicks(4542), "InProcess", "SubTitle 3", "Title 3", "Science" },
                    { 4, "Author name 4", null, "Information 4", true, new DateTime(2023, 5, 24, 10, 37, 3, 53, DateTimeKind.Local).AddTicks(4545), "InProcess", "SubTitle 4", "Title 4", "Sport" },
                    { 5, "Author name 5", null, "Information 5", false, new DateTime(2023, 5, 24, 10, 37, 3, 53, DateTimeKind.Local).AddTicks(4549), "InProcess", "SubTitle 5", "Title 5", "Technology" }
                });

            migrationBuilder.InsertData(
                table: "NewsTypes",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "World" },
                    { 2, "Local" },
                    { 3, "Sport" },
                    { 4, "Business" },
                    { 5, "Technology" },
                    { 6, "Science" },
                    { 7, "Health" },
                    { 8, "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "ProcessStatuses",
                columns: new[] { "Id", "Value" },
                values: new object[,]
                {
                    { 1, "InProcess" },
                    { 2, "Approved" },
                    { 3, "Editted" }
                });

            migrationBuilder.InsertData(
                table: "TelegramBotSettings",
                columns: new[] { "Id", "Key", "Value" },
                values: new object[,]
                {
                    { 1, "botApiKey", "6083733825:AAG3K3fm9JfTpa7ed1JVPJJiie0_KAw23Do" },
                    { 2, "chatId", "@some_channel_1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "NewsTypes");

            migrationBuilder.DropTable(
                name: "ProcessStatuses");

            migrationBuilder.DropTable(
                name: "TelegramBotSettings");
        }
    }
}

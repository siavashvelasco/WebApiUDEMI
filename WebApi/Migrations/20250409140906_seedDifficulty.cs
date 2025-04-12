using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class seedDifficulty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "DifficultySet",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("90eb3b13-245e-4a4a-b339-182262e47fd3"), "Medium" },
                    { new Guid("ce49d50e-9205-47d3-bacd-76188a374a0b"), "Easy" },
                    { new Guid("e6063157-694d-42d7-bbc1-9a3286fbe820"), "Hard" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("90eb3b13-245e-4a4a-b339-182262e47fd3"));

            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("ce49d50e-9205-47d3-bacd-76188a374a0b"));

            migrationBuilder.DeleteData(
                table: "DifficultySet",
                keyColumn: "Id",
                keyValue: new Guid("e6063157-694d-42d7-bbc1-9a3286fbe820"));
        }
    }
}

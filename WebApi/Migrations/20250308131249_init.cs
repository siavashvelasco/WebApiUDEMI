using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DifficultySet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultySet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegionSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WalkSet",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LenghthInKm = table.Column<double>(type: "float", nullable: false),
                    WalkImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DifficultyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalkSet_DifficultySet_DifficultyId",
                        column: x => x.DifficultyId,
                        principalTable: "DifficultySet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WalkSet_RegionSet_RegionId",
                        column: x => x.RegionId,
                        principalTable: "RegionSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WalkSet_DifficultyId",
                table: "WalkSet",
                column: "DifficultyId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkSet_RegionId",
                table: "WalkSet",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WalkSet");

            migrationBuilder.DropTable(
                name: "DifficultySet");

            migrationBuilder.DropTable(
                name: "RegionSet");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AutomobileCatalog.Server.Core.Migrations
{
    /// <inheritdoc />
    public partial class Test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Makes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Makes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleColors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MakeId = table.Column<int>(type: "int", nullable: false),
                    VehicleColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Makes_MakeId",
                        column: x => x.MakeId,
                        principalTable: "Makes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Models_VehicleColors_VehicleColorId",
                        column: x => x.VehicleColorId,
                        principalTable: "VehicleColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModelId = table.Column<int>(type: "int", nullable: false),
                    EngineCapacity = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_Models_VehicleModelId",
                        column: x => x.VehicleModelId,
                        principalTable: "Models",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InitialPriceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prices_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Mercedes" },
                    { 3, "Toyota" },
                    { 4, "Alfa Romeo" },
                    { 5, "Alphina" },
                    { 6, "Audi" },
                    { 7, "Acura" }
                });

            migrationBuilder.InsertData(
                table: "VehicleColors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Чорний" },
                    { 2, "Білий" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "MakeId", "Name", "VehicleColorId" },
                values: new object[,]
                {
                    { 1, 2, "e220", 1 },
                    { 2, 1, "e39", 2 },
                    { 3, 2, "190", 2 },
                    { 4, 2, "230 Pullman", 1 },
                    { 5, 2, "A-Class", 1 },
                    { 6, 2, "AMG GT", 1 },
                    { 7, 2, "AMG GT 4-Door Coupe", 1 },
                    { 8, 2, "B-Class", 1 },
                    { 9, 2, "C-Class", 1 },
                    { 10, 2, "C-Class All-Terrain", 1 },
                    { 11, 2, "Citan", 1 },
                    { 12, 2, "CL-Class", 1 },
                    { 13, 2, "CLA-Class", 1 },
                    { 14, 2, "CLC-Class", 1 },
                    { 15, 2, "CLK-Class", 1 },
                    { 16, 2, "CLS-Class", 1 },
                    { 17, 2, "G-Class", 1 },
                    { 18, 3, "Camry", 1 }
                });

            migrationBuilder.InsertData(
                table: "Vehicles",
                columns: new[] { "Id", "Description", "EngineCapacity", "ImageUrl", "PriceId", "VehicleModelId" },
                values: new object[,]
                {
                    { 1, "The best car", 2.0, null, 1, 1 },
                    { 2, "Test description", 1.6000000000000001, null, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "InitialPriceDate", "Value", "VehicleId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 3, 2, 16, 0, 26, 406, DateTimeKind.Local).AddTicks(3762), 19000m, 1 },
                    { 2, new DateTime(2023, 3, 2, 16, 0, 26, 406, DateTimeKind.Local).AddTicks(3812), 15000m, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Models_MakeId",
                table: "Models",
                column: "MakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_VehicleColorId",
                table: "Models",
                column: "VehicleColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prices_VehicleId",
                table: "Prices",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleModelId",
                table: "Vehicles",
                column: "VehicleModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prices");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropTable(
                name: "Makes");

            migrationBuilder.DropTable(
                name: "VehicleColors");
        }
    }
}

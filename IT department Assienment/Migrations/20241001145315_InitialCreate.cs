using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IT_department_Assienment.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DeviceCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeviceCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcquisitionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Memo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Devices_DeviceCategories_DeviceCategoryID",
                        column: x => x.DeviceCategoryID,
                        principalTable: "DeviceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "PropertyItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PropertyItems_DeviceCategories_DeviceCategoryID",
                        column: x => x.DeviceCategoryID,
                        principalTable: "DeviceCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DevicePropertyValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceID = table.Column<int>(type: "int", nullable: false),
                    PropertyItemID = table.Column<int>(type: "int", nullable: false),
                    PropertyValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DevicePropertyValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DevicePropertyValue_Devices_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Devices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DevicePropertyValue_PropertyItems_PropertyItemID",
                        column: x => x.PropertyItemID,
                        principalTable: "PropertyItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "DeviceCategories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Printer" },
                    { 2, "Laptop" },
                    { 3, "Switch" }
                });

            migrationBuilder.InsertData(
                table: "Devices",
                columns: new[] { "Id", "AcquisitionDate", "DeviceCategoryID", "Memo", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2014, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Office Desktop", "HP Desktop 1190" },
                    { 2, new DateTime(2018, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Color Printer", "Canon Printer 3000" },
                    { 3, new DateTime(2020, 5, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Network Switch", "Cisco Switch 2960" }
                });

            migrationBuilder.InsertData(
                table: "PropertyItems",
                columns: new[] { "Id", "Description", "DeviceCategoryID" },
                values: new object[,]
                {
                    { 1, "IP", 1 },
                    { 2, "Is Color", 1 },
                    { 3, "Brand", 1 },
                    { 4, "Processor", 2 },
                    { 5, "HD", 2 },
                    { 6, "RAM", 2 },
                    { 7, "Display", 2 },
                    { 8, "Current User", 2 },
                    { 9, "Ports", 3 },
                    { 10, "Speed", 3 },
                    { 11, "Brand", 3 }
                });

            migrationBuilder.InsertData(
                table: "DevicePropertyValue",
                columns: new[] { "Id", "DeviceID", "PropertyItemID", "PropertyValue" },
                values: new object[,]
                {
                    { 1, 1, 4, "Core i7" },
                    { 2, 1, 1, "192.168.1.5" },
                    { 3, 2, 1, "192.168.1.10" },
                    { 4, 2, 2, "Yes" },
                    { 5, 3, 9, "24" },
                    { 6, 3, 10, "1G" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DevicePropertyValue_DeviceID",
                table: "DevicePropertyValue",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_DevicePropertyValue_PropertyItemID",
                table: "DevicePropertyValue",
                column: "PropertyItemID");

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceCategoryID",
                table: "Devices",
                column: "DeviceCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyItems_DeviceCategoryID",
                table: "PropertyItems",
                column: "DeviceCategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DevicePropertyValue");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "PropertyItems");

            migrationBuilder.DropTable(
                name: "DeviceCategories");
        }
    }
}

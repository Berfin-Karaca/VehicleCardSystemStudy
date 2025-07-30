using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VehicleCardSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VEHICLETYPE",
                columns: table => new
                {
                    VEHICLETYPEID = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "(newid())"),
                    BRAND = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    MODELNAME = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CAPACITYKG = table.Column<double>(type: "REAL", nullable: false),
                    CAPACITYM3 = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLETYPE", x => x.VEHICLETYPEID);
                });

            migrationBuilder.CreateTable(
                name: "VEHICLE",
                columns: table => new
                {
                    VEHICLEID = table.Column<Guid>(type: "TEXT", nullable: false, defaultValueSql: "(newid())"),
                    PLATE = table.Column<string>(type: "TEXT", maxLength: 10, nullable: false),
                    MODELYEAR = table.Column<int>(type: "INTEGER", nullable: false),
                    COLOR = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    VEHICLETYPEID = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VEHICLE", x => x.VEHICLEID);
                    table.ForeignKey(
                        name: "FK_VEHICLE_VEHICLETYPE_VEHICLETYPEID",
                        column: x => x.VEHICLETYPEID,
                        principalTable: "VEHICLETYPE",
                        principalColumn: "VEHICLETYPEID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VEHICLE_VEHICLETYPEID",
                table: "VEHICLE",
                column: "VEHICLETYPEID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VEHICLE");

            migrationBuilder.DropTable(
                name: "VEHICLETYPE");
        }
    }
}

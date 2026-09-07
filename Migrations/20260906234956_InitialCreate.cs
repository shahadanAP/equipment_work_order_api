using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipmentApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AmountOfMembers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipmentAmount = table.Column<int>(type: "int", nullable: false),
                    EquipmentMake = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CrewMembers",
                columns: table => new
                {
                    CrewMembersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberPosition = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CrewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrewMembers", x => x.CrewMembersId);
                    table.ForeignKey(
                        name: "FK_CrewMembers_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CrewId = table.Column<int>(type: "int", nullable: false),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    DateOfWork = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipmentAssigned = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Crew_CrewId",
                        column: x => x.CrewId,
                        principalTable: "Crew",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrewMembers_CrewId",
                table: "CrewMembers",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_CrewId",
                table: "WorkOrders",
                column: "CrewId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_EquipmentId",
                table: "WorkOrders",
                column: "EquipmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CrewMembers");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Equipment");
        }
    }
}

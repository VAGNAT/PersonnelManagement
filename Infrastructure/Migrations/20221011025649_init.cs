using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    GroupDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Department_GroupDepartmentId",
                        column: x => x.GroupDepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelMovements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonnelMovements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonnelMovements_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonnelMovements_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "GroupDepartmentId", "Name" },
                values: new object[,]
                {
                    { 1, null, "Department of Human Resources Management" },
                    { 4, null, "Department of Finance" }
                });

            migrationBuilder.InsertData(
                table: "Employee",
                columns: new[] { "Id", "DateOfBirth", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(1963, 9, 21, 11, 56, 48, 979, DateTimeKind.Local).AddTicks(7685), "Brown", "Yundt" },
                    { 2, new DateTime(1993, 5, 13, 11, 56, 48, 979, DateTimeKind.Local).AddTicks(7705), "Alvina", "Schuppe" },
                    { 3, new DateTime(1978, 3, 26, 11, 56, 48, 979, DateTimeKind.Local).AddTicks(7706), "Jaeden", "Okuneva" },
                    { 4, new DateTime(1966, 2, 5, 11, 56, 48, 979, DateTimeKind.Local).AddTicks(7707), "Deangelo", "Bauch" },
                    { 5, new DateTime(1992, 10, 12, 11, 56, 48, 979, DateTimeKind.Local).AddTicks(7709), "Davonte", "White" },
                    { 6, new DateTime(1993, 7, 14, 11, 56, 48, 979, DateTimeKind.Local).AddTicks(7710), "Joy", "Buckridge" },
                    { 7, new DateTime(1972, 4, 4, 11, 56, 48, 979, DateTimeKind.Local).AddTicks(7711), "Madyson", "D'Amore" },
                    { 8, new DateTime(1988, 8, 19, 11, 56, 48, 979, DateTimeKind.Local).AddTicks(7711), "Ibrahim", "Rosenbaum" },
                    { 9, new DateTime(1966, 6, 30, 11, 56, 48, 979, DateTimeKind.Local).AddTicks(7712), "Dessie", "McGlynn" },
                    { 10, new DateTime(1977, 10, 21, 11, 56, 48, 979, DateTimeKind.Local).AddTicks(7713), "Laisha", "Glover" }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "Id", "GroupDepartmentId", "Name" },
                values: new object[,]
                {
                    { 2, 1, "Talent Planning, Acquisition and Development Division" },
                    { 3, 1, "Employee Service, Reletions and Policies Division" },
                    { 5, 4, "Budget Services Division" },
                    { 6, 4, "Accounts, Payments and Treasury Division" },
                    { 7, 4, "Financial Management of Technical Cooperation Division" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_GroupDepartmentId",
                table: "Department",
                column: "GroupDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelMovements_DepartmentId",
                table: "PersonnelMovements",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelMovements_EmployeeId",
                table: "PersonnelMovements",
                column: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnelMovements");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}

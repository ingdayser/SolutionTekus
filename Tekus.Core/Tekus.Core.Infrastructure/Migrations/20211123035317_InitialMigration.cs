using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tekus.Core.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nit = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Value = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    CreaterAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomAttribute",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Provider = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomAttribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomAttribute_Provider",
                        column: x => x.Provider,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProvider",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Provider = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Service = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreaterAt = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProvider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceProvider_Provider",
                        column: x => x.Provider,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceProvider_Service",
                        column: x => x.Service,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomAttribute_Provider",
                table: "CustomAttribute",
                column: "Provider");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProvider_Provider",
                table: "ServiceProvider",
                column: "Provider");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceProvider_Service",
                table: "ServiceProvider",
                column: "Service");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomAttribute");

            migrationBuilder.DropTable(
                name: "ServiceProvider");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Service");
        }
    }
}

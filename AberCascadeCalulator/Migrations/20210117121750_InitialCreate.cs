using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AberCascadeCalulator.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "module",
                columns: table => new
                {
                    module_id = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    coordinator = table.Column<string>(type: "text", nullable: true),
                    semester = table.Column<string>(type: "text", nullable: true),
                    year = table.Column<string>(type: "text", nullable: true),
                    department = table.Column<string>(type: "text", nullable: true),
                    credits = table.Column<long>(type: "interger", nullable: true),
                    welsh = table.Column<byte[]>(type: "bool", nullable: true),
                    url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_module", x => x.module_id);
                });

            migrationBuilder.CreateTable(
                name: "scheme",
                columns: table => new
                {
                    scheme_id = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: true),
                    award = table.Column<string>(type: "text", nullable: true),
                    department = table.Column<string>(type: "text", nullable: true),
                    undergraduate_or_postgraduate = table.Column<string>(type: "text", nullable: true),
                    scheme_type = table.Column<string>(type: "text", nullable: true),
                    year = table.Column<long>(type: "interger", nullable: true),
                    duration = table.Column<long>(type: "interger", nullable: true),
                    url = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheme", x => x.scheme_id);
                });

            migrationBuilder.CreateTable(
                name: "scheme_module",
                columns: table => new
                {
                    SchemeModuleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    scheme_id = table.Column<string>(type: "text", nullable: true),
                    module_id = table.Column<string>(type: "text", nullable: true),
                    module_type = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheme_module", x => x.SchemeModuleId);
                    table.ForeignKey(
                        name: "FK_scheme_module_module_module_id",
                        column: x => x.module_id,
                        principalTable: "module",
                        principalColumn: "module_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scheme_module_scheme_scheme_id",
                        column: x => x.scheme_id,
                        principalTable: "scheme",
                        principalColumn: "scheme_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scheme_module_module_id",
                table: "scheme_module",
                column: "module_id");

            migrationBuilder.CreateIndex(
                name: "IX_scheme_module_scheme_id",
                table: "scheme_module",
                column: "scheme_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scheme_module");

            migrationBuilder.DropTable(
                name: "module");

            migrationBuilder.DropTable(
                name: "scheme");
        }
    }
}

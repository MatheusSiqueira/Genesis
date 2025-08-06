using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Genesis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddMedicoTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicos",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CRM = table.Column<string>(type: "text", nullable: false),
                    Especialidade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicos",
                schema: "public");
        }
    }
}

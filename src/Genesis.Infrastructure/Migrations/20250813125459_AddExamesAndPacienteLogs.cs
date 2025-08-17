using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Genesis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddExamesAndPacienteLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "public",
                table: "Pacientes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "Pacientes",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                schema: "public",
                table: "Pacientes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "public",
                table: "Pacientes",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "public",
                table: "Pacientes",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                schema: "public",
                table: "Pacientes",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Exames",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PacienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Tipo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DataColeta = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DataAnalise = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ResultadoResumo = table.Column<string>(type: "text", nullable: true),
                    ResultadoArquivoUrl = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exames_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalSchema: "public",
                        principalTable: "Medicos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Exames_Pacientes_PacienteId",
                        column: x => x.PacienteId,
                        principalSchema: "public",
                        principalTable: "Pacientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Exames_MedicoId",
                schema: "public",
                table: "Exames",
                column: "MedicoId");

            migrationBuilder.CreateIndex(
                name: "IX_Exames_PacienteId_Status",
                schema: "public",
                table: "Exames",
                columns: new[] { "PacienteId", "Status" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Exames",
                schema: "public");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "public",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                schema: "public",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "DataCadastro",
                schema: "public",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "public",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "public",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                schema: "public",
                table: "Pacientes");
        }
    }
}

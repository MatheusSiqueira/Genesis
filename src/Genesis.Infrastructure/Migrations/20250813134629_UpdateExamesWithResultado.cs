using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Genesis.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateExamesWithResultado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exames_Medicos_MedicoId",
                schema: "public",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "DataColeta",
                schema: "public",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "ResultadoArquivoUrl",
                schema: "public",
                table: "Exames");

            migrationBuilder.AlterColumn<string>(
                name: "ResultadoResumo",
                schema: "public",
                table: "Exames",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicoId",
                schema: "public",
                table: "Exames",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "Exames",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataSolicitacao",
                schema: "public",
                table: "Exames",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ResultadoArquivo",
                schema: "public",
                table: "Exames",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Medicos_MedicoId",
                schema: "public",
                table: "Exames",
                column: "MedicoId",
                principalSchema: "public",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exames_Medicos_MedicoId",
                schema: "public",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "DataSolicitacao",
                schema: "public",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "ResultadoArquivo",
                schema: "public",
                table: "Exames");

            migrationBuilder.AlterColumn<string>(
                name: "ResultadoResumo",
                schema: "public",
                table: "Exames",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicoId",
                schema: "public",
                table: "Exames",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                schema: "public",
                table: "Exames",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataColeta",
                schema: "public",
                table: "Exames",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResultadoArquivoUrl",
                schema: "public",
                table: "Exames",
                type: "text",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Medicos_MedicoId",
                schema: "public",
                table: "Exames",
                column: "MedicoId",
                principalSchema: "public",
                principalTable: "Medicos",
                principalColumn: "Id");
        }
    }
}

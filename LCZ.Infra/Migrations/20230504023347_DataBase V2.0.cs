using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LCZ.Infra.Migrations
{
    public partial class DataBaseV20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RamoAtuacao",
                table: "Clientes",
                newName: "SituacaoCadastral");

            migrationBuilder.RenameColumn(
                name: "InscricaoEstadual",
                table: "Clientes",
                newName: "EmailCliente");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "SituacaoCadastral",
                table: "Clientes",
                newName: "RamoAtuacao");

            migrationBuilder.RenameColumn(
                name: "EmailCliente",
                table: "Clientes",
                newName: "InscricaoEstadual");
        }
    }
}

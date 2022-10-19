using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LABSOLOS.Migrations
{
    public partial class Anotacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Clientes",
                newName: "cpf");

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Clientes",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cpf",
                table: "Clientes",
                newName: "CPF");

            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Clientes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }
    }
}

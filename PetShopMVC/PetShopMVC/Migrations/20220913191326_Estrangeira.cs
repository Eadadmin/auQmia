using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopMVC.Migrations
{
    public partial class Estrangeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Telefone",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

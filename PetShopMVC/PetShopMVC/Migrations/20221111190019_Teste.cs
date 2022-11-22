using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopMVC.Migrations
{
    public partial class Teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Servico_ServicoId",
                table: "Servico");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Servico_ServicoId",
                table: "Servico",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Servico_Servico_ServicoId",
                table: "Servico");

            migrationBuilder.AddForeignKey(
                name: "FK_Servico_Servico_ServicoId",
                table: "Servico",
                column: "ServicoId",
                principalTable: "Servico",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

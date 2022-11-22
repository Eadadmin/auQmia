using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetShopMVC.Migrations
{
    public partial class Servico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Servico",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Ordem",
                columns: table => new
                {
                    OrdemId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrdemData = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordem", x => x.OrdemId);
                    table.ForeignKey(
                        name: "FK_Ordem_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdemDetalhe",
                columns: table => new
                {
                    OrdemDetalheId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrdemId = table.Column<int>(nullable: false),
                    ServicoId = table.Column<int>(nullable: false),
                    OrdemStatus = table.Column<int>(nullable: false),
                    ServicoName = table.Column<string>(nullable: true),
                    Preco = table.Column<decimal>(nullable: false),
                    ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdemDetalhe", x => x.OrdemDetalheId);
                    table.ForeignKey(
                        name: "FK_OrdemDetalhe_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdemDetalhe_Ordem_OrdemId",
                        column: x => x.OrdemId,
                        principalTable: "Ordem",
                        principalColumn: "OrdemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdemDetalhe_Servico_ServicoId",
                        column: x => x.ServicoId,
                        principalTable: "Servico",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordem_ClienteId",
                table: "Ordem",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDetalhe_ClienteId",
                table: "OrdemDetalhe",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDetalhe_OrdemId",
                table: "OrdemDetalhe",
                column: "OrdemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdemDetalhe_ServicoId",
                table: "OrdemDetalhe",
                column: "ServicoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdemDetalhe");

            migrationBuilder.DropTable(
                name: "Ordem");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Servico");
        }
    }
}

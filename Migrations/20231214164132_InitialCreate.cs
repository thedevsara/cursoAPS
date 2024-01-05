using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sarapaz.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    iditem = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    preco = table.Column<double>(type: "double", nullable: false),
                    quantidade = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    percentual = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.iditem);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pagamento",
                columns: table => new
                {
                    idpag = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    datalimite = table.Column<DateOnly>(type: "date", nullable: false),
                    valor = table.Column<double>(type: "double", nullable: false),
                    pago = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamento", x => x.idpag);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "produtos",
                columns: table => new
                {
                    idprod = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    preco = table.Column<double>(type: "double", nullable: false),
                    Itemid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.idprod);
                    table.ForeignKey(
                        name: "FK_produtos_items_Itemid",
                        column: x => x.Itemid,
                        principalTable: "items",
                        principalColumn: "iditem",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notavenda",
                columns: table => new
                {
                    codnota = table.Column<int>(name: "cod_nota", type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tipo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Pagamentoid = table.Column<int>(type: "int", nullable: false),
                    Itemid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notavenda", x => x.codnota);
                    table.ForeignKey(
                        name: "FK_Notavenda_Pagamento_Pagamentoid",
                        column: x => x.Pagamentoid,
                        principalTable: "Pagamento",
                        principalColumn: "idpag",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notavenda_items_Itemid",
                        column: x => x.Itemid,
                        principalTable: "items",
                        principalColumn: "iditem",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Marca",
                columns: table => new
                {
                    idmar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    none = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricao = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Produtoid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marca", x => x.idmar);
                    table.ForeignKey(
                        name: "FK_Marca_produtos_Produtoid",
                        column: x => x.Produtoid,
                        principalTable: "produtos",
                        principalColumn: "idprod",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idcliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notavendacod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.idcliente);
                    table.ForeignKey(
                        name: "FK_Clientes_Notavenda_Notavendacod",
                        column: x => x.Notavendacod,
                        principalTable: "Notavenda",
                        principalColumn: "cod_nota",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tipopagamento",
                columns: table => new
                {
                    idtipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomecobrado = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    informacaoadicionais = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notavendacod = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numerocart = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    bandeira = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    banco = table.Column<int>(type: "int", nullable: true),
                    nomebanco = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipopagamento", x => x.idtipo);
                    table.ForeignKey(
                        name: "FK_Tipopagamento_Notavenda_Notavendacod",
                        column: x => x.Notavendacod,
                        principalTable: "Notavenda",
                        principalColumn: "cod_nota",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "transportadoras",
                columns: table => new
                {
                    idtrans = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notavendacod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transportadoras", x => x.idtrans);
                    table.ForeignKey(
                        name: "FK_transportadoras_Notavenda_Notavendacod",
                        column: x => x.Notavendacod,
                        principalTable: "Notavenda",
                        principalColumn: "cod_nota",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vendedors",
                columns: table => new
                {
                    idvende = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nome = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Notavendacod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedors", x => x.idvende);
                    table.ForeignKey(
                        name: "FK_Vendedors_Notavenda_Notavendacod",
                        column: x => x.Notavendacod,
                        principalTable: "Notavenda",
                        principalColumn: "cod_nota",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Notavendacod",
                table: "Clientes",
                column: "Notavendacod");

            migrationBuilder.CreateIndex(
                name: "IX_Marca_Produtoid",
                table: "Marca",
                column: "Produtoid");

            migrationBuilder.CreateIndex(
                name: "IX_Notavenda_Itemid",
                table: "Notavenda",
                column: "Itemid");

            migrationBuilder.CreateIndex(
                name: "IX_Notavenda_Pagamentoid",
                table: "Notavenda",
                column: "Pagamentoid");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_Itemid",
                table: "produtos",
                column: "Itemid");

            migrationBuilder.CreateIndex(
                name: "IX_Tipopagamento_Notavendacod",
                table: "Tipopagamento",
                column: "Notavendacod");

            migrationBuilder.CreateIndex(
                name: "IX_transportadoras_Notavendacod",
                table: "transportadoras",
                column: "Notavendacod");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedors_Notavendacod",
                table: "Vendedors",
                column: "Notavendacod");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Marca");

            migrationBuilder.DropTable(
                name: "Tipopagamento");

            migrationBuilder.DropTable(
                name: "transportadoras");

            migrationBuilder.DropTable(
                name: "Vendedors");

            migrationBuilder.DropTable(
                name: "produtos");

            migrationBuilder.DropTable(
                name: "Notavenda");

            migrationBuilder.DropTable(
                name: "Pagamento");

            migrationBuilder.DropTable(
                name: "items");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoDados_Kasaleve_SistemaTudo.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    cargoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cargoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.cargoId);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    clienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteCPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteCEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteEnd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteCyti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteTel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    clienteRG = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    produtoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produtoNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    produtoValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    produtoFoto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.produtoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoProduto",
                columns: table => new
                {
                    tipoProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoProdutoNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoProduto", x => x.tipoProdutoId);
                });

            migrationBuilder.CreateTable(
                name: "Vendedora",
                columns: table => new
                {
                    vendedoraId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    vendedoraNome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedora", x => x.vendedoraId);
                });

            migrationBuilder.CreateTable(
                name: "logim",
                columns: table => new
                {
                    logimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logimNome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logimSenha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    logimEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cargoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logim", x => x.logimId);
                    table.ForeignKey(
                        name: "FK_logim_Cargo_cargoId",
                        column: x => x.cargoId,
                        principalTable: "Cargo",
                        principalColumn: "cargoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Praice",
                columns: table => new
                {
                    praiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    praiceValor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Praice", x => x.praiceId);
                    table.ForeignKey(
                        name: "FK_Praice_TipoProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TipoProduto",
                        principalColumn: "tipoProdutoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    orcamentoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dataOrcamento = table.Column<int>(type: "int", nullable: true),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    praiceId = table.Column<int>(type: "int", nullable: false),
                    vendedoraId = table.Column<int>(type: "int", nullable: false),
                    orcamnetoCorAluminio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orcamentoCorCorda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    orcamentoCorTecido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orcamento", x => x.orcamentoId);
                    table.ForeignKey(
                        name: "FK_Orcamento_Cliente_clienteId",
                        column: x => x.clienteId,
                        principalTable: "Cliente",
                        principalColumn: "clienteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orcamento_Praice_praiceId",
                        column: x => x.praiceId,
                        principalTable: "Praice",
                        principalColumn: "praiceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orcamento_Vendedora_vendedoraId",
                        column: x => x.vendedoraId,
                        principalTable: "Vendedora",
                        principalColumn: "vendedoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_logim_cargoId",
                table: "logim",
                column: "cargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_clienteId",
                table: "Orcamento",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_praiceId",
                table: "Orcamento",
                column: "praiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_vendedoraId",
                table: "Orcamento",
                column: "vendedoraId");

            migrationBuilder.CreateIndex(
                name: "IX_Praice_TipoProdutoId",
                table: "Praice",
                column: "TipoProdutoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logim");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Praice");

            migrationBuilder.DropTable(
                name: "Vendedora");

            migrationBuilder.DropTable(
                name: "TipoProduto");
        }
    }
}

using System;
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
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sobrenome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cpfCnpj = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    rg = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    endereco = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    cidade = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.clienteId);
                });

            migrationBuilder.CreateTable(
                name: "TipoProduto",
                columns: table => new
                {
                    tipoProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
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
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedora", x => x.vendedoraId);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    produtoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    tipoProdutoId = table.Column<int>(type: "int", nullable: true),
                    foto = table.Column<byte[]>(type: "LONGBLOB", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.produtoId);
                    table.ForeignKey(
                        name: "FK_Produto_TipoProduto_tipoProdutoId",
                        column: x => x.tipoProdutoId,
                        principalTable: "TipoProduto",
                        principalColumn: "tipoProdutoId");
                });

            migrationBuilder.CreateTable(
                name: "Orcamento",
                columns: table => new
                {
                    orcamentoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataOrcamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    clienteId = table.Column<int>(type: "int", nullable: false),
                    vendedoraId = table.Column<int>(type: "int", nullable: false),
                    corAluminio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    corCorda = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    corTecido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    valorFrete = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    termosCondicoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
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
                        name: "FK_Orcamento_Vendedora_vendedoraId",
                        column: x => x.vendedoraId,
                        principalTable: "Vendedora",
                        principalColumn: "vendedoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    senhaHash = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cargoId = table.Column<int>(type: "int", nullable: false),
                    vendedoraId = table.Column<int>(type: "int", nullable: true),
                    dataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usuarioId);
                    table.ForeignKey(
                        name: "FK_Usuario_Cargo_cargoId",
                        column: x => x.cargoId,
                        principalTable: "Cargo",
                        principalColumn: "cargoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Vendedora_vendedoraId",
                        column: x => x.vendedoraId,
                        principalTable: "Vendedora",
                        principalColumn: "vendedoraId");
                });

            migrationBuilder.CreateTable(
                name: "PrecoProduto",
                columns: table => new
                {
                    precoProdutoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    produtoId = table.Column<int>(type: "int", nullable: false),
                    valor = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    dataVigenciaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataVigenciaFim = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoProdutoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecoProduto", x => x.precoProdutoId);
                    table.ForeignKey(
                        name: "FK_PrecoProduto_Produto_produtoId",
                        column: x => x.produtoId,
                        principalTable: "Produto",
                        principalColumn: "produtoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PrecoProduto_TipoProduto_TipoProdutoId",
                        column: x => x.TipoProdutoId,
                        principalTable: "TipoProduto",
                        principalColumn: "tipoProdutoId");
                });

            migrationBuilder.CreateTable(
                name: "OrcamentoItem",
                columns: table => new
                {
                    orcamentoItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    orcamentoId = table.Column<int>(type: "int", nullable: false),
                    produtoId = table.Column<int>(type: "int", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    valorUnitario = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    descricaoItem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrcamentoItem", x => x.orcamentoItemId);
                    table.ForeignKey(
                        name: "FK_OrcamentoItem_Orcamento_orcamentoId",
                        column: x => x.orcamentoId,
                        principalTable: "Orcamento",
                        principalColumn: "orcamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrcamentoItem_Produto_produtoId",
                        column: x => x.produtoId,
                        principalTable: "Produto",
                        principalColumn: "produtoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    tarefaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    dataVencimento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    prioridade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    usuarioId = table.Column<int>(type: "int", nullable: true),
                    dataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.tarefaId);
                    table.ForeignKey(
                        name: "FK_Tarefa_Usuario_usuarioId",
                        column: x => x.usuarioId,
                        principalTable: "Usuario",
                        principalColumn: "usuarioId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_clienteId",
                table: "Orcamento",
                column: "clienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Orcamento_vendedoraId",
                table: "Orcamento",
                column: "vendedoraId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoItem_orcamentoId",
                table: "OrcamentoItem",
                column: "orcamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrcamentoItem_produtoId",
                table: "OrcamentoItem",
                column: "produtoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoProduto_produtoId",
                table: "PrecoProduto",
                column: "produtoId");

            migrationBuilder.CreateIndex(
                name: "IX_PrecoProduto_TipoProdutoId",
                table: "PrecoProduto",
                column: "TipoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produto_tipoProdutoId",
                table: "Produto",
                column: "tipoProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_usuarioId",
                table: "Tarefa",
                column: "usuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_cargoId",
                table: "Usuario",
                column: "cargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_vendedoraId",
                table: "Usuario",
                column: "vendedoraId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrcamentoItem");

            migrationBuilder.DropTable(
                name: "PrecoProduto");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropTable(
                name: "Orcamento");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "TipoProduto");

            migrationBuilder.DropTable(
                name: "Cargo");

            migrationBuilder.DropTable(
                name: "Vendedora");
        }
    }
}

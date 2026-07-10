using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BancoDados_Kasaleve_SistemaTudo.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoAddDetalhes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "foto",
                table: "Produto",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "LONGBLOB",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "foto",
                table: "Produto",
                type: "LONGBLOB",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }
    }
}

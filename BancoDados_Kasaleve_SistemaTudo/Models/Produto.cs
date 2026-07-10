using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        [Column("produtoId")]
        [Display(Name = "ID do Produto")]
        public int ProdutoId { get; set; }

        [Column("nome")]
        [Display(Name = "Nome do Produto")]
        [Required(ErrorMessage = "O nome do produto é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome do produto não pode exceder 255 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Column("descricao")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Column("valor", TypeName = "decimal(10, 2)")]
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor do produto é obrigatório.")]
        public decimal Valor { get; set; }

        [Column("tipoProdutoId")]
        [Display(Name = "ID do Tipo de Produto")]
        public int? TipoProdutoId { get; set; }

        [ForeignKey("TipoProdutoId")]
        public TipoProduto? TipoProduto { get; set; }

        [Column("foto", TypeName = "varbinary(max)")]
        [Display(Name = "Foto do Produto")]
        public byte[]? Foto { get; set; } // Armazenar imagem como byte array (BLOB)

        [Column("dataCadastro")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Column("ativo")]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; } = true;

        // Propriedade de navegação para Itens de Orçamento e Preços de Produto
        public ICollection<OrcamentoItem>? OrcamentoItens { get; set; }
        public ICollection<PrecoProduto>? PrecosProdutos { get; set; }
    }
}

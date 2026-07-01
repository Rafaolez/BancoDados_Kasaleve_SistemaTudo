using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        [Key]
        [Column("tipoProdutoId")]
        [Display(Name = "ID do Tipo de Produto")]
        public int TipoProdutoId { get; set; }

        [Column("nome")]
        [Display(Name = "Nome do Tipo de Produto")]
        [Required(ErrorMessage = "O nome do tipo de produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do tipo de produto não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        // Propriedade de navegação para Produtos
        public ICollection<Produto>? Produtos { get; set; }
        public ICollection<PrecoProduto>? PrecosProdutos { get; set; }
    }
}

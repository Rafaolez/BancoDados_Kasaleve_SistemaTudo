using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("OrcamentoItem")]
    public class OrcamentoItem
    {
        [Key]
        [Column("orcamentoItemId")]
        [Display(Name = "ID do Item do Orçamento")]
        public int OrcamentoItemId { get; set; }

        [Column("orcamentoId")]
        [Display(Name = "ID do Orçamento")]
        [Required(ErrorMessage = "O orçamento é obrigatório.")]
        public int OrcamentoId { get; set; }

        [ForeignKey("OrcamentoId")]
        public Orcamento? Orcamento { get; set; }

        [Column("produtoId")]
        [Display(Name = "ID do Produto")]
        [Required(ErrorMessage = "O produto é obrigatório.")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto? Produto { get; set; }

        [Column("quantidade")]
        [Display(Name = "Quantidade")]
        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [Column("valorUnitario", TypeName = "decimal(10, 2)")]
        [Display(Name = "Valor Unitário")]
        public decimal ValorUnitario { get; set; }

        [Column("descricaoItem")]
        [Display(Name = "Descrição do Item")]
        public string? DescricaoItem { get; set; }
    }
}

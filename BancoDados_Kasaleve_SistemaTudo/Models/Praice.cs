using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Praice")]
    public class Praice
    {
        [Column("praiceId")]
        [Display(Name = "praiceId")]
        public int praiceId { get; set; }

        [Column("praiceValor")]
        [Display(Name = "praiceValor")]
        public decimal praiceValor { get; set; }

        [ForeignKey("TipoProdutoId")]
        [Display(Name = "TipoProduto")]
        public int TipoProdutoId { get; set; }

        public TipoProduto? TipoProduto { get; set; }

    }
}

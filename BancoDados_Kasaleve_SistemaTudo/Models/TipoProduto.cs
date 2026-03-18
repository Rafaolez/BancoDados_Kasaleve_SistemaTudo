using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("TipoProduto")]
    public class TipoProduto
    {
        [Column("tipoProdutoId")]
        [Display(Name = "ID")]
        public int tipoProdutoId { get; set; }

        [Column("tipoProdutoNome")]
        [Display(Name = "Qual o tipo de preço ?")]
        public string tipoProdutoNome { get; set; } = string.Empty;


    }
}

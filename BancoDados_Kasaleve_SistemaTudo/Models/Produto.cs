using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Column("produtoId")]
        [Display(Name = "produtoId")]
        public int produtoId { get; set; }

        [Column("produtoNome")]
        [Display(Name = "produtoNome")]
        public string produtoNome { get; set; } = string.Empty;

        [Column("produtoValor")]
        [Display(Name = "produtoValor")]
        public decimal produtoValor { get; set; }

        [Column("produtoFoto")]
        [Display(Name = "produtoFoto")]
        public string produtoFoto { get; set; } = string.Empty;
    }
}

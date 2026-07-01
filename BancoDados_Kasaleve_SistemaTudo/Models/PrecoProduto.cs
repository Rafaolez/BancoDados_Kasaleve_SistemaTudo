using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("PrecoProduto")]
    public class PrecoProduto
    {
        [Key]
        [Column("precoProdutoId")]
        [Display(Name = "ID do Preço do Produto")]
        public int PrecoProdutoId { get; set; }

        [Column("produtoId")]
        [Display(Name = "ID do Produto")]
        [Required(ErrorMessage = "O produto é obrigatório.")]
        public int ProdutoId { get; set; }

        [ForeignKey("ProdutoId")]
        public Produto? Produto { get; set; }

        [Column("valor", TypeName = "decimal(10, 2)")]
        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O valor é obrigatório.")]
        public decimal Valor { get; set; }

        [Column("dataVigenciaInicio")]
        [Display(Name = "Data de Início da Vigência")]
        [DataType(DataType.Date)]
        public DateTime DataVigenciaInicio { get; set; } = DateTime.Today;

        [Column("dataVigenciaFim")]
        [Display(Name = "Data de Fim da Vigência")]
        [DataType(DataType.Date)]
        public DateTime? DataVigenciaFim { get; set; }
    }
}

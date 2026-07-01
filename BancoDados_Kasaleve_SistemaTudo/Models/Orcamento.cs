using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Orcamento")]
    public class Orcamento
    {
        [Key]
        [Column("orcamentoId")]
        [Display(Name = "ID do Orçamento")]
        public int OrcamentoId { get; set; }

        [Column("dataOrcamento")]
        [Display(Name = "Data do Orçamento")]
        public DateTime DataOrcamento { get; set; } = DateTime.Now;

        [Column("clienteId")]
        [Display(Name = "ID do Cliente")]
        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }

        [Column("vendedoraId")]
        [Display(Name = "ID da Vendedora")]
        [Required(ErrorMessage = "A vendedora é obrigatória.")]
        public int VendedoraId { get; set; }

        [ForeignKey("VendedoraId")]
        public Vendedora? Vendedora { get; set; }

        [Column("corAluminio")]
        [Display(Name = "Cor do Alumínio")]
        [StringLength(100, ErrorMessage = "A cor do alumínio não pode exceder 100 caracteres.")]
        public string? CorAluminio { get; set; }

        [Column("corCorda")]
        [Display(Name = "Cor da Corda")]
        [StringLength(100, ErrorMessage = "A cor da corda não pode exceder 100 caracteres.")]
        public string? CorCorda { get; set; }

        [Column("corTecido")]
        [Display(Name = "Cor do Tecido")]
        [StringLength(100, ErrorMessage = "A cor do tecido não pode exceder 100 caracteres.")]
        public string? CorTecido { get; set; }

        [Column("valorFrete", TypeName = "decimal(10, 2)")]
        [Display(Name = "Valor do Frete")]
        public decimal ValorFrete { get; set; } = 0.00M;

        [Column("observacoes")]
        [Display(Name = "Observações")]
        public string? Observacoes { get; set; }

        [Column("termosCondicoes")]
        [Display(Name = "Termos e Condições")]
        public string? TermosCondicoes { get; set; }

        [Column("status")]
        [Display(Name = "Status do Orçamento")]
        [StringLength(50, ErrorMessage = "O status não pode exceder 50 caracteres.")]
        public string Status { get; set; } = "Pendente";

        // Propriedade de navegação para Itens do Orçamento
        public ICollection<OrcamentoItem>? OrcamentoItens { get; set; }
    }
}

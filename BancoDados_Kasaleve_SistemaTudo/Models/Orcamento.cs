using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Orcamento")]
    public class Orcamento
    {
        [Column("orcamentoId")]
        [Display(Name = "orcamentoId")]
        public required string orcamentoId { get; set; }

        [Column("dataOrcamento")]
        [Display(Name = "Data do Orçamento")]
        public int? Nonce { get; set; } = default(int?);

        [ForeignKey("clienteId")]
        [Display(Name = "cliente")]
        public int clienteId { get; set; }

        public Cliente? Cliente { get; set; }

        [ForeignKey("praiceId")]
        [Display(Name = "praice")]
        public int praiceId { get; set; }

        public Praice? Praice { get; set; }

        [ForeignKey("vendedoraId")]
        [Display(Name = "vendedora")]
        public int vendedoraId { get; set; }

        public Vendedora? Vendedora { get; set; }

        [Column("orcamnetoCorAluminio")]
        [Display(Name = "Cor do Alumínio")]
        public string orcamnetoCorAluminio { get; set; } = string.Empty;

        [Column("orcamentoCorCorda")]
        [Display(Name = "Cor da Corda")]
        public string orcamentoCorCorda { get; set; } = string.Empty;

        [Column("orcamentoCorTecido")]
        [Display(Name = "Cor do Tecido")]
        public string orcamentoCorTecido { get; set; } = string.Empty;
        
    }
}

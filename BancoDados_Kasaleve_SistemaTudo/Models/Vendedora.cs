using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Vendedora")]
    public class Vendedora
    {
        [Column("vendedoraId")]
        [Display(Name = "vendedoraId")]
        public int vendedoraId { get; set; }

        [Column("vendedoraNome")]
        [Display(Name = "Nome vendedora")]
        public string vendedoraNome { get; set; } = string.Empty;
    }
}

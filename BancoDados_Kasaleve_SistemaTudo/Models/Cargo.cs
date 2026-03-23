using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Cargo")]
    public class Cargo
    {
        [Column("cargoId")]
        [Display(Name = "cargoId")]
        public int cargoId { get; set; }

        [Column("cargoNome")]
        [Display(Name = "Nome cargo")]
        public string cargoNome { get; set; } = string.Empty;
    }
}

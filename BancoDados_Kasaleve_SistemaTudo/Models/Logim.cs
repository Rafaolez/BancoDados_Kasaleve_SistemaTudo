using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("logim")]
    public class Logim
    {
        [Column("logimId")]
        [Display(Name = "ID")]
        public int LogimId { get; set; }

        [Column("logimNome")]
        [Display(Name = "Nome do Logim")]
        public string LogimNome { get; set; } = string.Empty;

        [Column("logimSenha")]
        [Display(Name = "Senha do Logim")]
        public string LogimSenha { get; set; } = string.Empty;

        [Column("logimEmail")]
        [Display(Name = "Email do Logim")]
        public string LogimEmail { get; set; } = string.Empty;

        [ForeignKey("cargoId")]
        [Display(Name = "cargo")]
        public int cargoId { get; set; }

        public Cargo? Cargo { get; set; }
    }
}

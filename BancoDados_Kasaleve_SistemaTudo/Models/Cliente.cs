using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Column("clienteId")]
        [Display(Name = "clienteId")]
        public int clienteId { get; set; }

        [Column("clienteNome")]
        [Display(Name = "Nome cliente")]
        public string clienteNome { get; set; } = string.Empty;

        [Column("clienteCPF")]
        [Display(Name = "CPF cliente")]
        public string clienteCPF { get; set; } = string.Empty;

        [Column("clienteCEP")]
        [Display(Name = "CEP cliente")]
        public string clienteCEP { get; set; } = string.Empty;

        [Column("clienteEnd")]
        [Display(Name = "Endereço cliente")]
        public string clienteEnd { get; set; } = string.Empty;

        [Column("clienteCyti")]
        [Display(Name = "Cidade cliente")]
        public string clienteCyti { get; set; } = string.Empty;

        [Column("clienteTel")]
        [Display(Name = "Telefone cliente")]
        public string clienteTel { get; set; } = string.Empty;

        [Column("clienteEmail")]
        [Display(Name = "Email cliente")]
        public string clienteEmail { get; set; } = string.Empty;

        [Column("clienteRG")]
        [Display(Name = "RG cliente")]
        public string clienteRG { get; set; } = string.Empty ;
    }
}

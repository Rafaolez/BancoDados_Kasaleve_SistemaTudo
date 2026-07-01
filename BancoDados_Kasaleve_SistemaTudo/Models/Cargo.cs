using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Cargo")]
    public class Cargo
    {
        [Key]
        [Column("cargoId")]
        [Display(Name = "ID do Cargo")]
        public int CargoId { get; set; }

        [Column("nome")]
        [Display(Name = "Nome do Cargo")]
        [Required(ErrorMessage = "O nome do cargo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do cargo não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        // Propriedade de navegação para Usuários
        public ICollection<Usuario>? Usuarios { get; set; }
    }
}

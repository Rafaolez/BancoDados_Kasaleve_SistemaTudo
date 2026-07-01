using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Vendedora")]
    public class Vendedora
    {
        [Key]
        [Column("vendedoraId")]
        [Display(Name = "ID da Vendedora")]
        public int VendedoraId { get; set; }

        [Column("nome")]
        [Display(Name = "Nome da Vendedora")]
        [Required(ErrorMessage = "O nome da vendedora é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome da vendedora não pode exceder 255 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Column("telefone")]
        [Display(Name = "Telefone")]
        [StringLength(20, ErrorMessage = "O telefone não pode exceder 20 caracteres.")]
        public string? Telefone { get; set; }

        [Column("email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        [StringLength(255, ErrorMessage = "O email não pode exceder 255 caracteres.")]
        public string? Email { get; set; }

        // Propriedade de navegação para Usuários e Orçamentos
        public ICollection<Usuario>? Usuarios { get; set; }
        public ICollection<Orcamento>? Orcamentos { get; set; }
    }
}

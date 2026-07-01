using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Column("usuarioId")]
        [Display(Name = "ID do Usuário")]
        public int UsuarioId { get; set; }

        [Column("nome")]
        [Display(Name = "Nome do Usuário")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome do usuário não pode exceder 255 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Column("email")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        [StringLength(255, ErrorMessage = "O email não pode exceder 255 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Column("senhaHash")]
        [Display(Name = "Hash da Senha")]
        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(255, ErrorMessage = "O hash da senha não pode exceder 255 caracteres.")]
        public string SenhaHash { get; set; } = string.Empty;

        [Column("cargoId")]
        [Display(Name = "ID do Cargo")]
        [Required(ErrorMessage = "O cargo é obrigatório.")]
        public int CargoId { get; set; }

        [ForeignKey("CargoId")]
        public Cargo? Cargo { get; set; }

        [Column("vendedoraId")]
        [Display(Name = "ID da Vendedora")]
        public int? VendedoraId { get; set; }

        [ForeignKey("VendedoraId")]
        public Vendedora? Vendedora { get; set; }

        [Column("dataCadastro")]
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; } = DateTime.Now;

        [Column("ativo")]
        [Display(Name = "Ativo")]
        public bool Ativo { get; set; } = true;

        // Propriedade de navegação para Tarefas
        public ICollection<Tarefa>? Tarefas { get; set; }
    }
}

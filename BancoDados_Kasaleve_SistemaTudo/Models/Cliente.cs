using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        [Column("clienteId")]
        [Display(Name = "ID do Cliente")]
        public int ClienteId { get; set; }

        [Column("nome")]
        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [StringLength(255, ErrorMessage = "O nome do cliente não pode exceder 255 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Column("sobrenome")]
        [Display(Name = "Sobrenome do Cliente")]
        [StringLength(255, ErrorMessage = "O sobrenome do cliente não pode exceder 255 caracteres.")]
        public string? Sobrenome { get; set; }

        [Column("cpfCnpj")]
        [Display(Name = "CPF/CNPJ")]
        [StringLength(20, ErrorMessage = "O CPF/CNPJ não pode exceder 20 caracteres.")]
        public string? CpfCnpj { get; set; }

        [Column("rg")]
        [Display(Name = "RG")]
        [StringLength(20, ErrorMessage = "O RG não pode exceder 20 caracteres.")]
        public string? Rg { get; set; }

        [Column("email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        [StringLength(255, ErrorMessage = "O email não pode exceder 255 caracteres.")]
        public string? Email { get; set; }

        [Column("telefone")]
        [Display(Name = "Telefone")]
        [StringLength(20, ErrorMessage = "O telefone não pode exceder 20 caracteres.")]
        public string? Telefone { get; set; }

        [Column("cep")]
        [Display(Name = "CEP")]
        [StringLength(10, ErrorMessage = "O CEP não pode exceder 10 caracteres.")]
        public string? Cep { get; set; }

        [Column("endereco")]
        [Display(Name = "Endereço")]
        [StringLength(255, ErrorMessage = "O endereço não pode exceder 255 caracteres.")]
        public string? Endereco { get; set; }

        [Column("cidade")]
        [Display(Name = "Cidade")]
        [StringLength(100, ErrorMessage = "A cidade não pode exceder 100 caracteres.")]
        public string? Cidade { get; set; }

        [Column("estado")]
        [Display(Name = "Estado")]
        [StringLength(50, ErrorMessage = "O estado não pode exceder 50 caracteres.")]
        public string? Estado { get; set; }

        [Column("status")]
        [Display(Name = "Status")]
        [StringLength(50, ErrorMessage = "O status não pode exceder 50 caracteres.")]
        public string Status { get; set; } = "Ativo";

        // Propriedade de navegação para Orçamentos
        public ICollection<Orcamento>? Orcamentos { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    [Table("Tarefa")]
    public class Tarefa
    {
        [Key]
        [Column("tarefaId")]
        [Display(Name = "ID da Tarefa")]
        public int TarefaId { get; set; }

        [Column("titulo")]
        [Display(Name = "Título")]
        [Required(ErrorMessage = "O título da tarefa é obrigatório.")]
        [StringLength(255, ErrorMessage = "O título não pode exceder 255 caracteres.")]
        public string Titulo { get; set; } = string.Empty;

        [Column("descricao")]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Column("dataVencimento")]
        [Display(Name = "Data de Vencimento")]
        [DataType(DataType.Date)]
        public DateTime? DataVencimento { get; set; }

        [Column("status")]
        [Display(Name = "Status")]
        [StringLength(50, ErrorMessage = "O status não pode exceder 50 caracteres.")]
        public string Status { get; set; } = "Pendente";

        [Column("prioridade")]
        [Display(Name = "Prioridade")]
        [StringLength(50, ErrorMessage = "A prioridade não pode exceder 50 caracteres.")]
        public string Prioridade { get; set; } = "Baixa";

        [Column("usuarioId")]
        [Display(Name = "ID do Usuário Responsável")]
        public int? UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario? Usuario { get; set; }

        [Column("dataCriacao")]
        [Display(Name = "Data de Criação")]
        public DateTime DataCriacao { get; set; } = DateTime.Now;
    }
}

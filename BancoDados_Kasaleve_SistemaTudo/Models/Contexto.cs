using Microsoft.EntityFrameworkCore;
using BancoDados_Kasaleve_SistemaTudo.Models;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        {

        }

        public DbSet<TipoProduto> TipoProduto { get; set; }
        public DbSet<Produto> Produto { get; set; } = default!;
        public DbSet<Praice> Praice { get; set; } = default!;
        public DbSet<BancoDados_Kasaleve_SistemaTudo.Models.Cliente> Cliente { get; set; } = default!;
        public DbSet<BancoDados_Kasaleve_SistemaTudo.Models.Vendedora> Vendedora { get; set; } = default!;
        public DbSet<BancoDados_Kasaleve_SistemaTudo.Models.Orcamento> Orcamento { get; set; } = default!;
        public DbSet<BancoDados_Kasaleve_SistemaTudo.Models.Cargo> Cargo { get; set; } = default!;
        public DbSet<BancoDados_Kasaleve_SistemaTudo.Models.Logim> Logim { get; set; } = default!;
    }
}

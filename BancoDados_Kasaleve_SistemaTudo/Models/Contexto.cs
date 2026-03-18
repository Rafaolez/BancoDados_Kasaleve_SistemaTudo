using Microsoft.EntityFrameworkCore;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        {

        }

        public DbSet<TipoProduto> Clientes { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace BancoDados_Kasaleve_SistemaTudo.Models
{
    public class Contexto : DbContext
    {
        public Contexto (DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public DbSet<Cargo> Cargo { get; set; } = default!;
        public DbSet<Vendedora> Vendedora { get; set; } = default!;
        public DbSet<Usuario> Usuario { get; set; } = default!; // Substitui Logim
        public DbSet<Cliente> Cliente { get; set; } = default!;
        public DbSet<TipoProduto> TipoProduto { get; set; } = default!;
        public DbSet<Produto> Produto { get; set; } = default!;
        public DbSet<Orcamento> Orcamento { get; set; } = default!;
        public DbSet<OrcamentoItem> OrcamentoItem { get; set; } = default!;
        public DbSet<Tarefa> Tarefa { get; set; } = default!;
        public DbSet<PrecoProduto> PrecoProduto { get; set; } = default!; // Substitui Praice

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurações adicionais para o modelo, se necessário
            // Exemplo: Chave composta, índices, etc.

            // Configuração para a propriedade Foto em Produto para MySQL (LONGBLOB)
            modelBuilder.Entity<Produto>()
                .Property(p => p.Foto)
                .HasColumnType("LONGBLOB");

            // Configuração para a propriedade SenhaHash em Usuario
            modelBuilder.Entity<Usuario>()
                .Property(u => u.SenhaHash)
                .IsRequired();

            // Configuração para o relacionamento entre Orcamento e OrcamentoItem
            modelBuilder.Entity<OrcamentoItem>()
                .HasOne(oi => oi.Orcamento)
                .WithMany(o => o.OrcamentoItens)
                .HasForeignKey(oi => oi.OrcamentoId)
                .OnDelete(DeleteBehavior.Cascade); // Exemplo: Deletar itens do orçamento ao deletar o orçamento

            base.OnModelCreating(modelBuilder);
        }
    }
}

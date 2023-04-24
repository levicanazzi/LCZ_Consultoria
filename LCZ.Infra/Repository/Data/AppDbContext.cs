using LCZ.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LCZ.Infra.Repository.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContatoCliente> ContatosCliente { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContatoCliente>()
                .HasOne(contato => contato.Cliente)
                .WithMany(cliente => cliente.ContatosCliente)
                .HasForeignKey(contato => contato.IdCliente);
        }
        
    }
}

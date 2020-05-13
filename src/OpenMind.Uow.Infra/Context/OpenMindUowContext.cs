using System.Linq;
using Microsoft.EntityFrameworkCore;
using OpenMind.Uow.Domain.Entities;
using OpenMind.Uow.Infra.Mappings;

namespace OpenMind.Uow.Infra.Context
{
    public class OpenMindUowContext : DbContext
    {
        public OpenMindUowContext(DbContextOptions<OpenMindUowContext> options) : base(options) { }

        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OpenMindUowContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
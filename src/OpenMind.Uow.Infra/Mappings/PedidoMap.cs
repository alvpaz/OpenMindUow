using Microsoft.EntityFrameworkCore;
using OpenMind.Uow.Domain.Entities;

namespace OpenMind.Uow.Infra.Mappings
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Pedido> builder)
        {
           
            // table
            builder.ToTable(TableName, TableSchema);

            // key
            builder.HasKey(t => t.PedidoId);

            // properties
            builder.Property(t => t.PedidoId)
                .IsRequired()
                .HasColumnName("PedidoId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Descricao)
                .HasColumnName("Name")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.Valor)
                .HasColumnName("Valor")
                .HasColumnType("decimal");

           
        }

        #region Generated Constants
        public const string TableSchema = "dbo";
        public const string TableName = "Pedido";
        #endregion
    }
}
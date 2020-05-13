using Microsoft.EntityFrameworkCore;
using OpenMind.Uow.Domain.Entities;

namespace OpenMind.Uow.Infra.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Produto> builder)
        {
           
            // table
            builder.ToTable(TableName, TableSchema);

            // key
            builder.HasKey(t => t.ProdutoId);

            // properties
            builder.Property(t => t.ProdutoId)
                .IsRequired()
                .HasColumnName("ProductId")
                .HasColumnType("int")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Descricao)
                .HasColumnName("Name")
                .HasColumnType("varchar(150)")
                .HasMaxLength(150);

            builder.Property(t => t.Valor)
                .HasColumnName("ParcelConfigurationId")
                .HasColumnType("decimal");

           
        }

        #region Generated Constants
        public const string TableSchema = "dbo";
        public const string TableName = "Produto";
        #endregion
    }
}
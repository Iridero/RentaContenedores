using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaContenedores.Configurations
{
    public class ContenedorConfiguration : IEntityTypeConfiguration<Contenedor>
    {
        public void Configure(EntityTypeBuilder<Contenedor> builder)
        {
            builder.ToTable("contenedor");
            builder.Property(c => c.Id)
                .UseMySqlIdentityColumn()
                .HasColumnName("id");
            builder.Property(c => c.Numero)
                .HasColumnName("numero")
                .IsRequired();
            builder.Property(c => c.Pasillo)
                .HasColumnName("pasillo")
                .HasMaxLength(2)
                .IsRequired();
            builder.Property(c => c.Dimensiones)
                .HasColumnName("dimensiones")
                .IsRequired()
                .HasMaxLength(5);
            builder.Property(c => c.Adeudo)
                .HasColumnName("adeudo")
                .HasDefaultValue(0)
                .HasColumnType("decimal(8,2)");
            builder.Property(c => c.UltimoPago)
                .HasColumnName("ultimo_pago");
            builder.HasIndex(c => c.IdCliente)
                .HasDatabaseName("id_cliente");
            builder.HasOne(c => c.Cliente)
                .WithMany(c => c.Contenedores)
                .HasForeignKey(c=>c.IdCliente)
                .HasConstraintName("fk_contenedor_cliente");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaContenedores.Configurations
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("cliente");
            builder.Property(c => c.Id)
                .HasColumnName("id")
                .UseMySqlIdentityColumn();
            builder.Property(c => c.Nombre)
                .HasColumnName("nombre")
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(c=>c.Telefono)
                .HasColumnName("telefono")
                .HasMaxLength(15)
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RentaContenedores.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentaContenedores.Data
{
    public class ContenedoresDataContext : DbContext
    {
        public ContenedoresDataContext()
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contenedor> Contenedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string cadena = "database=renta_contenedores;server=localhost;user=root;password=root";
            optionsBuilder.UseMySql(cadena, ServerVersion.AutoDetect(cadena));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClienteConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContenedorConfiguration).Assembly);

            modelBuilder.Entity<Contenedor>()
                .HasData(
                    new Contenedor
                    {
                        Numero = 1,
                        Dimensiones = "3x6",
                        Pasillo = "A",
                        Id= 1
                    },
                    new Contenedor
                    {
                        Numero = 2,
                        Dimensiones = "3x6",
                        Pasillo = "A",
                        Id= 2
                    },
                    new Contenedor
                    {
                        Numero = 3,
                        Dimensiones = "3x3",
                        Pasillo = "B",
                        Id= 3
                    },
                    new Contenedor
                    {
                        Numero = 4,
                        Dimensiones = "3x3",
                        Pasillo = "B",
                        Id=4,
                        IdCliente = 1
                    }

                ) ;
            modelBuilder.Entity<Cliente>()
                .HasData(
                new Cliente
                {
                    Id= 1,
                    Nombre="Juan Perez",
                    Telefono="55523412345"
                }
                );
        }
    }
}

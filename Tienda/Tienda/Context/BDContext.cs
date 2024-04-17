using Microsoft.EntityFrameworkCore;
using Tienda.Models;

namespace Tienda
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<Producto>().ToTable("productos");
            modelBuilder.Entity<Genero>().ToTable("generos");
            modelBuilder.Entity<Proveedor>().ToTable("proveedores");

            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasColumnType("decimal(18, 2)");
        }
    }
}



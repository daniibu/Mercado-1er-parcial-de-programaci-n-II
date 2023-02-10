using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MERCADO2.Core.Modelos;

namespace MERCADO2.UI.Data
{
    public class MERCADO2Context : DbContext
    {
        public MERCADO2Context (DbContextOptions<MERCADO2Context> options)
            : base(options)
        {
        }
        public DbSet<Marca>? Marca => Set<Marca>();
        public DbSet<Producto>? Producto => Set<Producto>();
        public DbSet<Proveedor>? Proveedor => Set<Proveedor>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Producto>().ToTable("Productos");
            modelBuilder.Entity<Marca>().ToTable("Marcas");
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores");
        }
    }
}

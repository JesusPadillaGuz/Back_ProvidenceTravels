using API_Agencia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Agencia.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Abono> Abonos { get; set; }
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<PersonaExtra> PersonasExtra { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Sesion> Sesiones { get; set; }
        public DbSet<TipoPersona> TiposPersona { get; set; }
        public DbSet<TipoServicio> TiposServicio { get; set; }
        public DbSet<TipoUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abono>().HasOne(x => x.Contrato).WithMany(x => x.Abonos).OnDelete(DeleteBehavior.Restrict);

        }
    }
}

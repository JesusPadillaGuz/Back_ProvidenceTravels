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
            modelBuilder.Entity<TipoUsuario>()
                .Property(b => b.IsEnabled)
                .HasDefaultValue(true);

            modelBuilder.Entity<Usuario>()
               .Property(b => b.IsEnabled)
               .HasDefaultValue(true);

            modelBuilder.Entity<TipoServicio>()
               .Property(b => b.IsEnabled)
               .HasDefaultValue(true);

            modelBuilder.Entity<Sesion>()
               .Property(b => b.IsEnabled)
               .HasDefaultValue(true);

            modelBuilder.Entity<Contrato>()
               .Property(b => b.IsEnabled)
               .HasDefaultValue(true);

            modelBuilder.Entity<Paquete>()
               .Property(b => b.IsEnabled)
               .HasDefaultValue(true);

            modelBuilder.Entity<Abono>().HasOne(x => x.Contrato).WithMany(x => x.Abonos).OnDelete(DeleteBehavior.Restrict);

            //default data
            modelBuilder.Entity<Usuario>().HasData(
              new Usuario { ID = 1, Nombre = "Jose", Apellido = "Padilla", IsEnabled=true,TipoUsuarioID=1,AccesoID=1, },
              new Usuario { ID = 2, Nombre = "Cynthia", Apellido = "Delgado", IsEnabled = true, TipoUsuarioID = 1, AccesoID = 2, },
              new Usuario { ID = 3, Nombre = "Ramon", Apellido = "Perez", IsEnabled = true, TipoUsuarioID = 2, AccesoID = 3, }
              );

            modelBuilder.Entity<TipoUsuario>().HasData(
             new TipoUsuario { ID = 1, Nombre = "Administrador", Descripcion = "Se encarga de manejar/administrar todo el sistema", IsEnabled=true },
             new TipoUsuario { ID = 2, Nombre = "Empleado", Descripcion = "Trabajador de la empresa.", IsEnabled = true }
             );

            modelBuilder.Entity<TipoServicio>().HasData(
             new TipoServicio { ID = 1, Nombre = "Hotel", Descripcion = "Solo Hospedaje (Todo Incluido)", IsEnabled = true },
             new TipoServicio { ID = 2, Nombre = "Hotel Plan Europeo", Descripcion = "Solo Hospedaje(sin alimentos)", IsEnabled = true },
             new TipoServicio { ID = 3, Nombre = "Hotel + Transporte ", Descripcion = "Hospedaje mas transporte ", IsEnabled = true }
             );

            modelBuilder.Entity<Servicio>().HasData(
            new Servicio { ID = 1, Descripcion = "4 dias 3 noches Hotel Riu Vallarta, Nuevo Vallarta", Fecha_Inicio = new DateTime(2021, 5, 1, 8, 30, 52), Fecha_Fin= new DateTime(2021, 5, 4, 8, 30, 52), TipoServicioID=1 },
            new Servicio { ID = 2, Descripcion = "4 dias 3 noches Hotel San Marino, Vallarta. Transporte Incluido", Fecha_Inicio = new DateTime(2021, 7, 7, 8, 30, 52), Fecha_Fin = new DateTime(2021, 7, 11, 8, 30, 52), TipoServicioID = 3 }
            );

        }
    }
}

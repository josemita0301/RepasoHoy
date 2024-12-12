using Formularios.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Formularios.Infraestructure.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Formulario> Formulario { get; set; }
        public DbSet<FormularioCampo> FormularioCampo { get; set; }
        public DbSet<FormularioRespuesta> FormularioRespuesta { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Relación Formulario -> Usuario
            modelBuilder.Entity<Formulario>()
                .HasOne(f => f.Usuario)
                .WithMany()
                .HasForeignKey(f => f.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Formulario -> FormularioCampo (1:N)
            modelBuilder.Entity<Formulario>()
                .HasMany(f => f.Campos)
                .WithOne(c => c.Formulario)
                .HasForeignKey(c => c.FormularioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Relación Formulario -> FormularioRespuesta (1:N)
            modelBuilder.Entity<Formulario>()
                .HasMany(f => f.Respuestas)
                .WithOne(r => r.Formulario)
                .HasForeignKey(r => r.FormularioId)
                .OnDelete(DeleteBehavior.Restrict);


            // Relación FormularioRespuesta -> Usuario
            modelBuilder.Entity<FormularioRespuesta>()
                .HasOne(r => r.Usuario)
                .WithMany()
                .HasForeignKey(r => r.UsuarioId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

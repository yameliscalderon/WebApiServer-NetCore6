using Microsoft.EntityFrameworkCore;
using WebApiUsers.Models;
namespace WebApiUsers.Context
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Users>? usuarios { get; set; }
        public virtual DbSet<Vehicles>? vehiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("usuarios");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Rut).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Nombre).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Apellido).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.AnoNacimiento).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(10).IsUnicode(false);

            });

            modelBuilder.Entity<Vehicles>(entity =>
            {
                entity.ToTable("vehiculos");
                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Patente).HasMaxLength(6).IsUnicode(false);
                entity.Property(e => e.Ano).IsUnicode(false);
                entity.Property(e => e.Modelo).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Marca).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Color).HasMaxLength(50).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);

        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    } //fin clase
} //fin namespace
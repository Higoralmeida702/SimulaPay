using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimulaPay.Domain.Models;

namespace SimulaPay.Infra.Data.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<CarteiraEntity> Carteiras { get; set; }
        public DbSet<TransferenciaEntity> Transferencias { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CarteiraEntity>()
                .HasIndex(w => new { w.CPFCNPJ, w.Email })
                .IsUnique();

            modelBuilder.Entity<CarteiraEntity>()
                .Property(t => t.SaldoDeConta)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<CarteiraEntity>()
                .Property(w => w.TipoUsuario)
                .HasConversion<string>();

            modelBuilder.Entity<TransferenciaEntity>()
                .HasKey(t => t.TransferenciaId);

            modelBuilder.Entity<TransferenciaEntity>()
                .HasOne(t => t.Remetente)
                .WithMany()
                .HasForeignKey(t => t.RemetenteId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transaction_Remetente");

            modelBuilder.Entity<TransferenciaEntity>()
                .Property(t => t.Valor)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<TransferenciaEntity>()
                .HasOne(t => t.Receptor)
                .WithMany()
                .HasForeignKey(t => t.ReceptorId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Transaction_Receptor");
        }

    }
}
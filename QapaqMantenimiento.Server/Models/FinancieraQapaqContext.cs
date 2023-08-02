using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QapaqMantenimiento.Server.Models
{
    public partial class FinancieraQapaqContext : DbContext
    {
        public FinancieraQapaqContext()
        {
        }

        public FinancieraQapaqContext(DbContextOptions<FinancieraQapaqContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Incidente> Incidentes { get; set; } = null!;
        public virtual DbSet<SubTipo> SubTipos { get; set; } = null!;
        public virtual DbSet<TipoIncidente> TipoIncidentes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Incidente>(entity =>
            {
                entity.HasKey(e => e.IdIncidente)
                    .HasName("PK__INCIDENT__E92B13DFA55EACE1");

                entity.ToTable("INCIDENTE");

                entity.Property(e => e.DetalleIncidente)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FechaRegistro).HasColumnType("date");

                entity.Property(e => e.NomAgencia)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NomApeUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NommbrePc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NommbrePC");

                entity.Property(e => e.ReportadoMediante)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoContacto)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.TipoOficina)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubTipo>(entity =>
            {
                entity.HasKey(e => e.IdSubTipo)
                    .HasName("PK__SUB_TIPO__7452D806CCD4B215");

                entity.ToTable("SUB_TIPO");

                entity.Property(e => e.IdSubTipo)
                    .ValueGeneratedNever()
                    .HasColumnName("Id_SubTipo");

                entity.Property(e => e.AreaEncargada)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SubTipoIncidente)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("SubTipo_incidente");

                entity.HasOne(d => d.IdTipoIncidenteNavigation)
                    .WithMany(p => p.SubTipos)
                    .HasForeignKey(d => d.IdTipoIncidente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_tipo_subtipo");
            });

            modelBuilder.Entity<TipoIncidente>(entity =>
            {
                entity.HasKey(e => e.IdTipoIncidente)
                    .HasName("PK__TIPO_INC__F796430A47169DD3");

                entity.ToTable("TIPO_INCIDENTE");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

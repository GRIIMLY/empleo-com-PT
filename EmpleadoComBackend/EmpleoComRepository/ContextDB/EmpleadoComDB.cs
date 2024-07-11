using System;
using System.Collections.Generic;
using EmpleoComRepository.Models;
using Microsoft.EntityFrameworkCore;

namespace EmpleoComRepository.ContextDB;

public partial class EmpleadoComDB : DbContext
{
    public EmpleadoComDB()
    {
    }

    public EmpleadoComDB(DbContextOptions<EmpleadoComDB> options)
        : base(options)
    {
    }

    public virtual DbSet<Demandante> Demandantes { get; set; }

    public virtual DbSet<DescripcionesTrabajo> DescripcionesTrabajos { get; set; }

    public virtual DbSet<Emparejamiento> Emparejamientos { get; set; }

    public virtual DbSet<Empleadore> Empleadores { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Habilidad> Habilidads { get; set; }

    public virtual DbSet<HabilidadUsuarioTrabajo> HabilidadUsuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Demandante>(entity =>
        {
            entity.HasKey(e => e.DemandanteId).HasName("PK__Demandan__7A25B674F9021A7B");

            entity.Property(e => e.DemandanteId)
                .ValueGeneratedNever()
                .HasColumnName("DemandanteID");
            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.ExperienciaLaboral).HasMaxLength(500);
            entity.Property(e => e.NivelEducacion).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Notas).HasMaxLength(500);

           
        });

        modelBuilder.Entity<DescripcionesTrabajo>(entity =>
        {
            entity.HasKey(e => e.TrabajoId).HasName("PK__Descripc__FCD3CD5E8A923701");

            entity.ToTable("DescripcionesTrabajo");

            entity.Property(e => e.TrabajoId).HasColumnName("TrabajoID");
            entity.Property(e => e.Descripcion).HasMaxLength(500);
            entity.Property(e => e.EmpleadorId).HasColumnName("EmpleadorID");
            entity.Property(e => e.FechaPublicacion).HasColumnType("date");
            entity.Property(e => e.Requisitos).HasMaxLength(500);
            entity.Property(e => e.Titulo).HasMaxLength(100);

            entity.HasOne(d => d.Empleador).WithMany(p => p.DescripcionesTrabajos)
                .HasForeignKey(d => d.EmpleadorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Descripci__Emple__3F466844");
        });

        modelBuilder.Entity<Emparejamiento>(entity =>
        {
            entity.HasKey(e => e.EmparejamientoId).HasName("PK__Empareja__52AF4F338CD52F38");

            entity.Property(e => e.EmparejamientoId).HasColumnName("EmparejamientoID");
            entity.Property(e => e.DemandanteId).HasColumnName("DemandanteID");
            entity.Property(e => e.FechaEmparejamiento).HasColumnType("date");
            entity.Property(e => e.TrabajoId).HasColumnName("TrabajoID");
            entity.HasOne(d => d.Trabajo).WithMany(p => p.Emparejamientos)
                .HasForeignKey(d => d.TrabajoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Emparejam__Traba__4316F928");
        });

        modelBuilder.Entity<Empleadore>(entity =>
        {
            entity.HasKey(e => e.EmpleadorId).HasName("PK__Empleado__DD0B9D9F77179C76");

            entity.Property(e => e.EmpleadorId)
                .ValueGeneratedNever()
                .HasColumnName("EmpleadorID");
            entity.Property(e => e.Industria).HasMaxLength(50);
            entity.Property(e => e.Localizacion).HasMaxLength(100);
            entity.Property(e => e.NombreEmpresa).HasMaxLength(100);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE79856C7FF79");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Contrasenia).HasMaxLength(100);
            entity.Property(e => e.NombreUsuario).HasMaxLength(50);
            entity.Property(e => e.TipoUsuario).HasMaxLength(10);
        });

        modelBuilder.Entity<Habilidad>(entity =>
        {
            entity.HasKey(e => e.HabilidadId).HasName("PK__Habilida__7341FFC2F0DCABF2");

            entity.ToTable("Habilidad");

            entity.Property(e => e.HabilidadId)
                .ValueGeneratedNever()
                .HasColumnName("HabilidadID");
            entity.Property(e => e.NombreHabilidad).HasMaxLength(100);
        });



        modelBuilder.Entity<HabilidadUsuarioTrabajo>(entity =>
        {
            entity.HasKey(e => e.HabilidadUsuarioId).HasName("PK__Habilida__D4EC5D3261537209");

            entity.ToTable("HabilidadUsuarioTrabajo");

            entity.Property(e => e.HabilidadUsuarioId).HasColumnName("HabilidadUsuarioID");
            entity.Property(e => e.HabilidadId).HasColumnName("HabilidadID");
            entity.Property(e => e.TrabajoId).HasColumnName("TrabajoID");
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

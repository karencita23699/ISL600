using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Proyecto.Models.BD;

public partial class DbFutbolContext : DbContext
{
    public DbFutbolContext()
    {
    }

    public DbFutbolContext(DbContextOptions<DbFutbolContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Arbitro> Arbitros { get; set; }

    public virtual DbSet<Campeonato> Campeonatos { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<Estadistica> Estadisticas { get; set; }

    public virtual DbSet<Fixture> Fixtures { get; set; }

    public virtual DbSet<Jugadore> Jugadores { get; set; }

    public virtual DbSet<Resultado> Resultados { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-NU5FUDB; Database=DB_Futbol; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arbitro>(entity =>
        {
            entity.HasKey(e => e.ArbitroId).HasName("PK__Arbitros__67970F800148349A");

            entity.Property(e => e.ArbitroId).HasColumnName("ArbitroID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Campeonato>(entity =>
        {
            entity.HasKey(e => e.CampeonatoId).HasName("PK__Campeona__020946A198B46152");

            entity.Property(e => e.CampeonatoId).HasColumnName("CampeonatoID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Campeonatos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Campeonat__Usuar__5CD6CB2B");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.EquipoId).HasName("PK__Equipos__DE8A0BFFD38C152D");

            entity.Property(e => e.EquipoId).HasColumnName("EquipoID");
            entity.Property(e => e.CapitanId).HasColumnName("CapitanID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Estadistica>(entity =>
        {
            entity.HasKey(e => e.EstadisticaId).HasName("PK__Estadist__5E78B5ECCDB5BAC9");

            entity.Property(e => e.EstadisticaId).HasColumnName("EstadisticaID");
            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.FixtureId).HasColumnName("FixtureID");
            entity.Property(e => e.JugadorId).HasColumnName("JugadorID");
            entity.Property(e => e.TipoEstadistica).HasMaxLength(50);

            entity.HasOne(d => d.Fixture).WithMany(p => p.Estadisticas)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("FK__Estadisti__Fixtu__4AB81AF0");

            entity.HasOne(d => d.Jugador).WithMany(p => p.Estadisticas)
                .HasForeignKey(d => d.JugadorId)
                .HasConstraintName("FK__Estadisti__Jugad__4BAC3F29");
        });

        modelBuilder.Entity<Fixture>(entity =>
        {
            entity.HasKey(e => e.FixtureId).HasName("PK__Fixtures__26465BF607E0ED43");

            entity.Property(e => e.FixtureId).HasColumnName("FixtureID");
            entity.Property(e => e.ArbitroId).HasColumnName("ArbitroID");
            entity.Property(e => e.CampeonatoId).HasColumnName("CampeonatoID");
            entity.Property(e => e.EquipoLocalId).HasColumnName("EquipoLocalID");
            entity.Property(e => e.EquipoVisitanteId).HasColumnName("EquipoVisitanteID");
            entity.Property(e => e.Lugar).HasMaxLength(100);

            entity.HasOne(d => d.Arbitro).WithMany(p => p.Fixtures)
                .HasForeignKey(d => d.ArbitroId)
                .HasConstraintName("FK__Fixtures__Arbitr__4316F928");

            entity.HasOne(d => d.Campeonato).WithMany(p => p.Fixtures)
                .HasForeignKey(d => d.CampeonatoId)
                .HasConstraintName("FK__Fixtures__Campeo__403A8C7D");

            entity.HasOne(d => d.EquipoLocal).WithMany(p => p.FixtureEquipoLocals)
                .HasForeignKey(d => d.EquipoLocalId)
                .HasConstraintName("FK__Fixtures__Equipo__412EB0B6");

            entity.HasOne(d => d.EquipoVisitante).WithMany(p => p.FixtureEquipoVisitantes)
                .HasForeignKey(d => d.EquipoVisitanteId)
                .HasConstraintName("FK__Fixtures__Equipo__4222D4EF");
        });

        modelBuilder.Entity<Jugadore>(entity =>
        {
            entity.HasKey(e => e.JugadorId).HasName("PK__Jugadore__4B575242CC2A2689");

            entity.Property(e => e.JugadorId).HasColumnName("JugadorID");
            entity.Property(e => e.EquipoId).HasColumnName("EquipoID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Posicion).HasMaxLength(50);

            entity.HasOne(d => d.Equipo).WithMany(p => p.Jugadores)
                .HasForeignKey(d => d.EquipoId)
                .HasConstraintName("FK__Jugadores__Equip__398D8EEE");
        });

        modelBuilder.Entity<Resultado>(entity =>
        {
            entity.HasKey(e => e.ResultadoId).HasName("PK__Resultad__7904DD411055DA1B");

            entity.Property(e => e.ResultadoId).HasColumnName("ResultadoID");
            entity.Property(e => e.FixtureId).HasColumnName("FixtureID");
            entity.Property(e => e.GolesLocal).HasDefaultValue(0);
            entity.Property(e => e.GolesVisitante).HasDefaultValue(0);

            entity.HasOne(d => d.Fixture).WithMany(p => p.Resultados)
                .HasForeignKey(d => d.FixtureId)
                .HasConstraintName("FK__Resultado__Fixtu__47DBAE45");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7989A1A464E");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Rol).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

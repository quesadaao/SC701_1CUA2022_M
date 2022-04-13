using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class AkiraToriyamaContext : DbContext
    {
        public AkiraToriyamaContext()
        {
        }

        public AkiraToriyamaContext(DbContextOptions<AkiraToriyamaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Anime> Anime { get; set; }
        public virtual DbSet<Capitulo> Capitulo { get; set; }
        public virtual DbSet<Temporada> Temporada { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SCIIV2;Database=AkiraToriyama;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Anime>(entity =>
            {
                entity.Property(e => e.Creacion).HasColumnType("date");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Modificado).HasColumnType("date");

                entity.Property(e => e.ModificadoPor).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Capitulo>(entity =>
            {
                entity.Property(e => e.Creacion).HasColumnType("date");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Modificacion).HasColumnType("date");

                entity.Property(e => e.ModificadoPor).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.IdAnimeNavigation)
                    .WithMany(p => p.Capitulo)
                    .HasForeignKey(d => d.IdAnime)
                    .HasConstraintName("FK_Capitulo_Anime");

                entity.HasOne(d => d.IdTemporadaNavigation)
                    .WithMany(p => p.Capitulo)
                    .HasForeignKey(d => d.IdTemporada)
                    .HasConstraintName("FK_Capitulo_Temporada");
            });

            modelBuilder.Entity<Temporada>(entity =>
            {
                entity.Property(e => e.Creacion).HasColumnType("date");

                entity.Property(e => e.Descripcion).HasMaxLength(50);

                entity.Property(e => e.Modificacion).HasColumnType("date");

                entity.Property(e => e.ModificadoPor).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.HasOne(d => d.IdAnimeNavigation)
                    .WithMany(p => p.Temporada)
                    .HasForeignKey(d => d.IdAnime)
                    .HasConstraintName("FK_Temporada_Anime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

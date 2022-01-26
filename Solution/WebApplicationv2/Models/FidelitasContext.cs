using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace WebApplicationv2.Models
{
    public partial class FidelitasContext : DbContext
    {
        public FidelitasContext()
        {
        }

        public FidelitasContext(DbContextOptions<FidelitasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Carrera> Carrera { get; set; }
        public virtual DbSet<Feedbacks> Feedbacks { get; set; }
        public virtual DbSet<Pies> Pies { get; set; }
        public virtual DbSet<Pies13> Pies13 { get; set; }
        public virtual DbSet<Universidad> Universidad { get; set; }
        public virtual DbSet<Vuelo> Vuelo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SCIIV2;Database=Fidelitas;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<Carrera>(entity =>
            {
                entity.Property(e => e.Creacion).HasColumnType("datetime");

                entity.Property(e => e.Decano)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.GradoAcademico)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RequisitoGraduacion)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUniversidadNavigation)
                    .WithMany(p => p.Carrera)
                    .HasForeignKey(d => d.IdUniversidad)
                    .HasConstraintName("FK_Carrera_Universidad");
            });

            modelBuilder.Entity<Feedbacks>(entity =>
            {
                entity.HasKey(e => e.FeedbackId);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Message).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Pies>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Pies13>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ImageThumbnailUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LongDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ShortDescription)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Universidad>(entity =>
            {
                entity.Property(e => e.Dominio)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Fundacion).HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vuelo>(entity =>
            {
                entity.HasKey(e => e.IId)
                    .HasName("PK__Vuelo__DC512D921B95C979");

                entity.Property(e => e.IId).HasColumnName("iId");

                entity.Property(e => e.BActivo).HasColumnName("bActivo");

                entity.Property(e => e.DPesoMaximoMaletas)
                    .HasColumnName("dPesoMaximoMaletas")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DValoracionUsuarios)
                    .HasColumnName("dValoracionUsuarios")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DtDestinoViaje)
                    .HasColumnName("dtDestinoViaje")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtHoraLlegada)
                    .HasColumnName("dtHoraLlegada")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtHoraSalida)
                    .HasColumnName("dtHoraSalida")
                    .HasColumnType("datetime");

                entity.Property(e => e.DtSalidadViaje)
                    .HasColumnName("dtSalidadViaje")
                    .HasColumnType("datetime");

                entity.Property(e => e.ICantidadPasajeros).HasColumnName("iCantidadPasajeros");

                entity.Property(e => e.IFeedback).HasColumnName("iFeedback");

                entity.Property(e => e.ITipoPasajero).HasColumnName("iTipoPasajero");

                entity.Property(e => e.NNombreAvion)
                    .IsRequired()
                    .HasColumnName("nNombreAvion")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.VAerolinea)
                    .IsRequired()
                    .HasColumnName("vAerolinea")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IFeedbackNavigation)
                    .WithMany(p => p.Vuelo)
                    .HasForeignKey(d => d.IFeedback)
                    .HasConstraintName("FK_Vuelo_Feedbacks");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

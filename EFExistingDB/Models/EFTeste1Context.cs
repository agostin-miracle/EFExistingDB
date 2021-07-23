using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFExistingDB.Models
{
    public partial class EFTeste1Context : DbContext
    {
        public EFTeste1Context()
        {
        }

        public EFTeste1Context(DbContextOptions<EFTeste1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<EstadoCivil> EstadoCivil { get; set; }
        public virtual DbSet<Generos> Generos { get; set; }
        public virtual DbSet<Uf> Uf { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(Localdb)\\MSSQLLOCALDB;Database=EFTeste1;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EstadoCivil>(entity =>
            {
                entity.HasKey(e => e.CodEstCivil);

                entity.Property(e => e.DesEstCivil)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Generos>(entity =>
            {
                entity.HasKey(e => e.CodGenero);

                entity.Property(e => e.CodGenero)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DesGenero)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Uf>(entity =>
            {
                entity.HasKey(e => e.CodUf);

                entity.ToTable("UF");

                entity.Property(e => e.CodUf)
                    .HasColumnName("CodUF")
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DesUf)
                    .IsRequired()
                    .HasColumnName("DesUF")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.Codusu);

                entity.Property(e => e.Codusu)
                    .HasColumnName("CODUSU")
                    .ValueGeneratedNever();

                entity.Property(e => e.CodAtr).HasDefaultValueSql("((1))");

                entity.Property(e => e.CodCmf)
                    .IsRequired()
                    .HasColumnName("CodCMF")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.CodPju)
                    .IsRequired()
                    .HasColumnName("CodPJU")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.DatAtualizacao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DatCadastro)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Datnascto)
                    .HasColumnName("DATNascto")
                    .HasColumnType("datetime");

                entity.Property(e => e.NomMae)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.NomUsuario)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Numrg)
                    .IsRequired()
                    .HasColumnName("NUMRG")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrgEmi)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Starec)
                    .HasColumnName("STAREC")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TipGen)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Ufemi)
                    .IsRequired()
                    .HasColumnName("UFEmi")
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.CodEstCivilNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.CodEstCivil)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_EstadoCivil");

                entity.HasOne(d => d.TipGenNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.TipGen)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Generos");

                entity.HasOne(d => d.UfemiNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.Ufemi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_UF");
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SampleMVC5_0.Models
{
    public partial class GestionBanquesContext : DbContext
    {
        public GestionBanquesContext()
        {
        }

        public GestionBanquesContext(DbContextOptions<GestionBanquesContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banque> Banques { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Compte> Comptes { get; set; }

        /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-N5P4MBO; Database=GestionBanques; uid=derbali; pwd=sqlderbali;");
            }
        }
 */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Banque>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nom)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Ville)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Nom)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Prenom)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Compte>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BanqueId).HasColumnName("BanqueID");

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Banque)
                    .WithMany(p => p.Comptes)
                    .HasForeignKey(d => d.BanqueId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Comptes)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

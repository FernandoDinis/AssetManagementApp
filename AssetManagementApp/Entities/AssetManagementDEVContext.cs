using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AssetManagementApp.Entities
{
    public partial class AssetManagementDEVContext : DbContext
    {
        public virtual DbSet<Asset> Asset { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Status> Status { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-QS70DLB\SQLEXPRESS;Initial Catalog=AssetManagementDEV;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssetId).HasColumnName("AssetID");

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

                entity.Property(e => e.LastUpdate).HasColumnType("date");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.HasOne(d => d.Asset)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.AssetId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Document_Emplyee_EmployeeID");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.StatusId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Label)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
        }
    }
}

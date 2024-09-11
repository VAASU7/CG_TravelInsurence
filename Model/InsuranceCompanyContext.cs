using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Travel_Insurance.Model
{
    public partial class InsuranceCompanyContext : DbContext
    {
        public InsuranceCompanyContext()
        {
        }

        public InsuranceCompanyContext(DbContextOptions<InsuranceCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agent> Agents { get; set; }

        public virtual DbSet<Claim1> Claims { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public virtual DbSet<Policy> Policies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Travel_Insu;Username=postgres;Password=rvs@9866");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>(entity =>
            {
                entity.HasKey(e => e.AgentId).HasName("PK__Agents__9AC3BFD12309DED6");

                entity.Property(e => e.AgentId)
                    .ValueGeneratedNever()
                    .HasColumnName("AgentID");
                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Claim1>(entity =>
            {
                entity.HasKey(e => e.ClaimId).HasName("PK__Claims__EF2E13BB86A1F247");

                entity.Property(e => e.ClaimId)
                    .ValueGeneratedNever()
                    .HasColumnName("ClaimID");
                entity.Property(e => e.ClaimAmount).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ClaimDetails).HasColumnType("text");
                entity.Property(e => e.ClaimStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.PolicyId).HasColumnName("PolicyID");
                entity.Property(e => e.ProcessorComments).HasColumnType("text");

                entity.HasOne(d => d.Policy).WithMany(p => p.Claims)
                    .HasForeignKey(d => d.PolicyId)
                    .HasConstraintName("FK__Claims__PolicyID__29572725");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B824C23CDC");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerID");
                entity.Property(e => e.Address).HasColumnType("text");
                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58497FBAEF");

                entity.Property(e => e.PaymentId)
                    .ValueGeneratedNever()
                    .HasColumnName("PaymentID");
                entity.Property(e => e.AmountPaid).HasColumnType("decimal(10, 2)");
                entity.Property(e => e.ClaimId).HasColumnName("ClaimID");
                entity.Property(e => e.PaymentMethod)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.TransactionId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TransactionID");

                entity.HasOne(d => d.Claim).WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ClaimId)
                    .HasConstraintName("FK__Payments__ClaimI__2C3393D0");
            });

            modelBuilder.Entity<Policy>(entity =>
            {
                entity.HasKey(e => e.PolicyId).HasName("PK__Policies__2E13394459265849");

                entity.Property(e => e.PolicyId)
                    .ValueGeneratedNever()
                    .HasColumnName("PolicyID");
                entity.Property(e => e.CoverageDetails).HasColumnType("text");
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
                entity.Property(e => e.PolicyNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.PremiumAmount).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Customer).WithMany(p => p.Policies)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Policies__Custom__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
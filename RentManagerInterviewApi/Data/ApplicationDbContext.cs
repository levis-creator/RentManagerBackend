using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentManagerInterviewApi.Models.Entities;

namespace RentManagerInterviewApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Invoice> PropertyOwners { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<LeaseAgreement> LeaseAgreements { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentTransfer> PaymentTransfers { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Unit> Units { get; set; }

        //relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //PropertyOwner
            modelBuilder.Entity<PropertyOwner>()
                .HasMany(p => p.Apartments)
                .WithOne(a => a.PropertyOwner)
                .HasForeignKey(a => a.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);
            //Apartments
            modelBuilder.Entity<Apartment>()
                .HasMany(a => a.Units)
                .WithOne(u => u.Apartment)
                .HasForeignKey(u => u.ApartmentId)
                .OnDelete(DeleteBehavior.Cascade);
            //unit
            modelBuilder.Entity<Unit>()
                .HasOne(u => u.Tenant)
                .WithOne(t => t.Unit)
                .HasForeignKey<Tenant>()
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
            // Configure Status as a computed column
            modelBuilder.Entity<Unit>()
              .Property(u => u.Status)
              .HasDefaultValue(UnitStatus.Available);

            // Ensure LeaseAgreement and PaymentTransfers are also restricted to avoid conflicts
            modelBuilder.Entity<LeaseAgreement>()
                .HasOne(l => l.Tenant)
                .WithMany(t => t.LeaseAgreements)
                .HasForeignKey(l => l.TenantId)
                .OnDelete(DeleteBehavior.Cascade); // ✅ Prevents multiple cascade paths
            modelBuilder.Entity<LeaseAgreement>()
                .HasOne(l => l.Unit)
                .WithMany()
                .HasForeignKey(l => l.UnitId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<PaymentTransfer>()
                .HasOne(p => p.Tenant)
                .WithMany(t => t.PaymentTransfers)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<PaymentTransfer>()
            .HasOne(p => p.ToUnit)
            .WithMany()
            .HasForeignKey(p => p.ToUnitId)
            .OnDelete(DeleteBehavior.SetNull);
            //modelBuilder.Entity<LeaseAgreement>()
            //    .HasOne(l => l.Unit)
            //    .WithOne(u => u.LeaseAgreement)
            //    .HasForeignKey<Unit>();
            //invoice
            modelBuilder.Entity<Invoice>()
                .HasOne(i => i.LeaseAgreement)
                .WithMany(l => l.Invoices)
                .HasForeignKey(i => i.LeaseId);
            //Payment
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Invoice)
                .WithMany(i => i.Payments)
                .HasForeignKey(p => p.InvoiceId);
            base.OnModelCreating(modelBuilder);
        }

     
    }
}

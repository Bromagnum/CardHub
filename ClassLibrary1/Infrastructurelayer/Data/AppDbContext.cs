using DomainLayer.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Infrastructurelayer.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<CreditCard> CreditCards { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.ToTable("CreditCards");

                entity.HasKey(c => c.Id);

                entity.Property(c => c.CardName)
                      .IsRequired()
                      .HasMaxLength(100);

                entity.Property(c => c.BankName)
                      .HasMaxLength(100);

                entity.Property(c => c.CardType)
                      .HasMaxLength(50);

                entity.Property(c => c.Limit)
                      .HasColumnType("decimal(18,2)");

                entity.Property(c => c.CurrentBalance)
                      .HasColumnType("decimal(18,2)");

                entity.Property(c => c.BillingCycleStart)
                      .HasColumnType("date");

                entity.Property(c => c.BillingCycleEnd)
                      .HasColumnType("date");

                entity.Property(c => c.BenefitsJson)
                      .HasColumnType("nvarchar(max)");

                entity.Property(c => c.CreatedDate)
                      .HasDefaultValueSql("GETUTCDATE()");

                entity.Property(c => c.UpdatedDate)
                      .IsRequired(false);
            });
        }


    }
}


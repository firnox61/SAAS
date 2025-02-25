using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class DataContext:DbContext
    {
        public const string DEFAULT_SCHEMA = "usering";
        public DataContext() // Parametresiz constructor eklendi
        {
        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1466;Database=userdb;User Id=sa;Password=Password123*;TrustServerCertificate=True;");
            }
        }
      
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);

            modelBuilder.Entity<User>().ToTable("Users", DEFAULT_SCHEMA)
                .HasKey(u => u.Id);

            modelBuilder.Entity<UserOperationClaim>().ToTable("UserOperationClaims", DEFAULT_SCHEMA)
                .HasKey(uoc => uoc.Id);

            modelBuilder.Entity<OperationClaim>().ToTable("OperationClaims", DEFAULT_SCHEMA)
                .HasKey(oc => oc.Id);

            modelBuilder.Entity<UserOperationClaim>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(uoc => uoc.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserOperationClaim>()
                .HasOne<OperationClaim>()
                .WithMany()
                .HasForeignKey(uoc => uoc.OperationClaimId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models.DataModel
{
    public partial class ATMECSDBContext : DbContext
    {
        public ATMECSDBContext()
        {
        }

        public ATMECSDBContext(DbContextOptions<ATMECSDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblContacts> TblContacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {
            if (!optionsBuilder.IsConfigured)
            {
                var Con = Startup.GetConnectionString();
                optionsBuilder.UseSqlServer(Con);
               
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblContacts>(entity =>
            {
                entity.ToTable("Tbl_Contacts");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

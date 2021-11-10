using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DesignPluz.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
        }

        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<AddressTypes> AddressTypes { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Addresses>()
                .Property(e => e.StreetAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Addresses>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Addresses>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<AddressTypes>()
                .Property(e => e.AddressType)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.firstname)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.lastname)
                .IsUnicode(false);

            modelBuilder.Entity<Customers>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Genders>()
                .Property(e => e.Gender)
                .IsUnicode(false);
        }
    }
}

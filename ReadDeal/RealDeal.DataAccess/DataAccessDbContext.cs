using System;

using Microsoft.EntityFrameworkCore;

using RealDeal.AppLogic.Models;

namespace RealDeal.DataAccess
{
    public class DataAccessDbContext : DbContext
    {
        public DataAccessDbContext(DbContextOptions<DataAccessDbContext> options)
            : base(options)
        {
        }

        //public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<AuctionRegistration> AuctionRegistrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionRegistration>()
                .HasKey(pk => new { pk.UserID, pk.ItemID });

            //modelBuilder.Entity<SomeObject>().Property(m => m.somefield).IsOptional();
            //base.OnModelCreating(modelBuilder);
        }
    }
}

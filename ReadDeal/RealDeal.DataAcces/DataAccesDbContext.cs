﻿using System;

using Microsoft.EntityFrameworkCore;

using RealDeal.AppLogic.Models;

namespace RealDeal.DataAcces
{
    public class DataAccesDbContext : DbContext
    {
        public DataAccesDbContext(DbContextOptions<DataAccesDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<AuctionRegistration> AuctionRegistrations { get; set; }
        public DbSet<History> Histories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionRegistration>()
                .HasKey(pk => new { pk.UserID, pk.ItemID });

            modelBuilder.Entity<History>()
                .HasKey(pk => new { pk.UserID, pk.ItemID });
        }
    }
}

﻿using GroupAssignment2.Areas.Identity.Data;
using GroupAssignment2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroupAssignment2.DAL
{
    public class HousingDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public HousingDbContext(DbContextOptions<HousingDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Housing> Housings { get; set; }
        public DbSet<ApplicationUser> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.ApplyConfiguration(new ApplicationUserEntityConfiguration());

        }

        public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
        {

            public void Configure(EntityTypeBuilder<ApplicationUser> builder)
            {
                builder.Property(u => u.FirstName).HasMaxLength(255);
                builder.Property(u => u.LastName).HasMaxLength(255);
                
            }
        }
    }
}

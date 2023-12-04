﻿using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;


namespace ClothBazar.Database
{
    public class CBContext :DbContext,IDisposable
    {
        public CBContext() :base("CBConnection")
        { 
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public IEnumerable<object> FeaturedCategories { get; set; }
        public DbSet<Config> Configurations { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}

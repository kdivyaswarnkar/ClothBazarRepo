using ClothBazar.Entities;
using System;
using System.Data.Entity;


namespace ClothBazar.Database
{
    public class CBContext :DbContext,IDisposable
    {
        public CBContext() :base("CBConnection")
        { 
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

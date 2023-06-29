using ClothBazar.Entities;
using System.Data.Entity;


namespace ClothBazar.Database
{
    public class CBContext :DbContext
    {
        public CBContext() :base("CBConnection")
        { 
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}

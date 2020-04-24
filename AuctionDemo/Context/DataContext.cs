using AuctionDemo.Entities;
using System.Data.Entity;

namespace AuctionDemo.Context
{
    public class DataContext : DbContext
    {
        public DataContext() : base("ProductContext")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
using System.Data.Entity;

namespace Store.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("name=StoreDBEntities")
        {
        }
    
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLineItem> OrderLineItems { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
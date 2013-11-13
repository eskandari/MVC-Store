using System.Collections.Generic;

namespace Store.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>();
        }
    
        public int Id { get; set; }
        public string SSN { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
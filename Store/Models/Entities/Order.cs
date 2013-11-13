using System;
using System.Collections.Generic;

namespace Store.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderLineItems = new List<OrderLineItem>();
        }
    
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime Date { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenStoreApp.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int BookId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }
        public string Status { get; set; }
        public string Name { get; set; } // Completed or Pending

        //OrderItems property to hold the list of items in the order
        public List<OrderItem> OrderItems { get; set; }
    }

}

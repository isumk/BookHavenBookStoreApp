using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenStoreApp.Models
{
    public class Sale
    {
        public int SaleID { get; set; }  // Unique identifier for the sale
        public int CustomerID { get; set; }  // ID of the customer who made the purchase
        public DateTime SaleDate { get; set; }  // Date when the sale was made
        public decimal TotalAmount { get; set; }  // Total amount of the sale before discount
        public decimal Discount { get; set; }  // Discount applied to the sale
        public List<OrderItem> OrderItems { get; set; }  // List of items in the order
    }
}

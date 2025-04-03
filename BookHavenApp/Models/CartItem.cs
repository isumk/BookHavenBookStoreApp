using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHavenStoreApp;

namespace BookHavenStoreApp.Models
{
    namespace BookHavenApp.Models
    {
        public class CartItem
        {
            public int BookId { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }

            // Computed property to get total amount per item
            public decimal Total
            {
                get { return Price * Quantity; }
            }
        }
    }


}

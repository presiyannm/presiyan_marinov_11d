using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace presiyan_marinov_11d.Data.Models
{
    public class Stock
    {
        public Stock()
        {
        }

        public Stock(string productName, decimal productPrice, int quantity, Provider provider)
        {
            ProductName = productName;
            ProductPrice = productPrice;
            Quantity = quantity;
            Provider = provider;
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice  { get; set; }
        public int Quantity { get; set; }
        public Provider Provider { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameWorld.Models
{
    public class Cart
    {
        public Cart()
        {
            CartLines = new List<Product>();
        }
        public List<Product> CartLines { get; set; }
        public int FinalPrice
        {
            get
            {
                int sum = 0;
                foreach (Product product in CartLines)
                {
                    sum += product.Product_Price;
                }
                return sum;
            }
        }
    }
}

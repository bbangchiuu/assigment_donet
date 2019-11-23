using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assigment.Models
{
    public class BuyItem
    {
        public List<Product> ListProducts = new List<Product>();

        public void AddProduct(Product product, int Quantity)
        {
            product.Quantity = Quantity;
            ListProducts.Add(product);
        }
    }
}
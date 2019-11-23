using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assigment.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public long Price { get; set; }
        public string Desciption { get; set; }
        public int Quantity { get; set; }
        public virtual Category Category { get; set; }
    }
}
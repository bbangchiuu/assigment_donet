using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace assigment.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment2.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public String Name { get; set; }
        public int QtyInStock { get; set; }
        public String Description { get; set; }
        public string Supplier { get; set; }

    }
}
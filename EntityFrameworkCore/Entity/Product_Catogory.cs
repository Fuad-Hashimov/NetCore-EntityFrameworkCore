using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Entity
{
    public class Product_Catogory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Product_Catogory> Product_Catogories { get; set; }
    }
}

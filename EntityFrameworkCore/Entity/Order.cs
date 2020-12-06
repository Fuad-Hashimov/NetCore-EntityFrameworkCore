using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Entity
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TaxNumber { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}

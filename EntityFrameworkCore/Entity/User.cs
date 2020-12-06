using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore.Entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<Address> Addresses { get; set; }

        public Customer Customer { get; set; }

        public Supplier Supplier { get; set; }
    }
}

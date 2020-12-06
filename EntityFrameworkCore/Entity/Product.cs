using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityFrameworkCore.Entity
{
    public class Product
    {

        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
        public decimal Price { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime InsertDate { get; set; } = DateTime.Now;

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;


        public List<Product_Catogory> Product_Catogories { get; set; }


    }
}

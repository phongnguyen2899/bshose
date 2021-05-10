using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bshoes.Data.Entiti
{
   public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(200)]
        [Required]
        public  string Name { get; set; }
        [MaxLength(200)]
        [Required]
        public string Decription { get; set; }

        public decimal Price { get; set; }

        public decimal OniginalPrice { get; set; }

        public int Quantity { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public int Stock { get; set; }

        public int ViewCount { get; set; }

        public DateTime DateCreated { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        public List<Cart> Carts { get; set; }
        public List<ProductImage> ProductImages { get; set; }

    }
}

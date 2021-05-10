using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bshoes.Data.Entiti
{
   public class OrderDetail
    {
        [Key]
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}

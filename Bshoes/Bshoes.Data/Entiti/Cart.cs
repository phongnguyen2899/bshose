using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bshoes.Data.Entiti
{
    [Table("Cart")]
  public  class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        //public Guid UserId { get; set; }

        public Product Product { get; set; }

        public DateTime DateCreated { get; set; }

    }
}

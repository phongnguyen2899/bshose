using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bshoes.Data.Entiti
{
    [Table("Order")]
   public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        [MaxLength(200)]
        [Required]
        public string ShipName { set; get; }
        [MaxLength(200)]
        [Required]
        public string ShipAddress { set; get; }
        [MaxLength(200)]
        [Required]
        public string ShipEmail { set; get; }
        [MaxLength(200)]
        [Required]
        public string ShipPhoneNumber { set; get; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}

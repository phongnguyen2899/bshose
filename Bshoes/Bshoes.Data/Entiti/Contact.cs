using Bshoes.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bshoes.Data.Entiti
{
   public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { set; get; }
        [MaxLength(200)]
        [Required]
        public string Name { set; get; }
        [MaxLength(200)]
        [Required]
        public string Email { set; get; }
        [MaxLength(200)]
        [Required]
        public string PhoneNumber { set; get; }
        [Required]
        public string Message { set; get; }
        public Status Status { set; get; }
    }
}

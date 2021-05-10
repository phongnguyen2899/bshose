using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bshoes.Data.Entiti
{
   public class Menu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [MaxLength(200)]
        [Required]
        public string Link { get; set; }
        public int DisplayOrder { get; set; }
        public bool Status { get; set; }
    }
}

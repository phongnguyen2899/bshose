using Bshoes.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bshoes.Data.Entiti
{
   public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public bool IsShowHome { get; set; }
        public Status Status { get; set; }
        public virtual List<Product> Products { get; set; }
    }
}

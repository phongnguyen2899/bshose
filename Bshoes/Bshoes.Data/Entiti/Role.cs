using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bshoes.Data.Entiti
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
    }
}

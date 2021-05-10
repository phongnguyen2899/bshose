using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.Data.Entiti
{
   public class UserRole
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public virtual User user { get; set; }
    }
}

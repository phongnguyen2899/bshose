using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.ViewModel.Common
{
   public class PageResult<T>:PageResultBase
    {
        public List<T> Item { get; set; }
        public int totalRecord { get; set; }
    }
}

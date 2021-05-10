using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.ViewModel.Common
{
   public class PageResultBase
    {
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        public int totalRecord { get; set; }
    }
}

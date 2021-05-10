using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.ViewModel.Common
{
   public class PagingRequestBase
    {
        public int pageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

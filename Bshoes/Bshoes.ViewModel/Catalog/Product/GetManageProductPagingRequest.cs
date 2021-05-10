using Bshoes.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.ViewModel.Product
{
   public class GetManageProductPagingRequest:PagingRequestBase
    {
        public string Keyword { get; set; }
        public int? categoryId { get; set; }
    }
}

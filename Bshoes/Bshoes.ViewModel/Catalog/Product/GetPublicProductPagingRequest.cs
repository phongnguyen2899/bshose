using Bshoes.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.ViewModel.Catalog.Product
{
   public class GetPublicProductPagingRequest: PagingRequestBase
    {
        public int ? categoryId { get; set; }
    }
}

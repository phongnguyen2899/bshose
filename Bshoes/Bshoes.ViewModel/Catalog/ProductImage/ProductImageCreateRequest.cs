using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.ViewModel.Catalog.ProductImage
{
   public class ProductImageCreateRequest
    {
        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public int SortOrder { get; set; }

        public string ImageFile { get; set; }
    }
}

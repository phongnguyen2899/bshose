using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.ViewModel.Catalog.Product
{
   public class ProductUpdateRequest
    {
        public string Name { get; set; }
        public string Decription { get; set; }
        public decimal OniginalPrice { get; set; }
        public int Quantity { get; set; }

        public int Stock { get; set; }
    }
}

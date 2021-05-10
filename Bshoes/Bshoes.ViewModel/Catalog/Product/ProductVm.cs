using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.ViewModel.Catalog.Product
{
   public class ProductVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Decription { get; set; }

        public decimal Price { get; set; }

        public decimal OniginalPrice { get; set; }

        public int Quantity { get; set; }

        public int Stock { get; set; }
        public int ViewCount { get; set; }

    }
}

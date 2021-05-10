using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.ViewModel.Catalog.Product
{
   public class ProductCreateRequest
    {
        public string Name { get; set; }
        public string Decription { get; set; }

        public decimal Price { get; set; }

        public decimal OniginalPrice { get; set; }


        public int Stock { get; set; }
        public int cateoryId { get; set; }
    }
}

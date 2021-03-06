using System;
using System.Collections.Generic;
using System.Text;

namespace Bshoes.ViewModel.Catalog.ProductImage
{
   public class ProductImageViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public string ImagePath { get; set; }

        public string Caption { get; set; }

        public DateTime DateCreated { get; set; }

        public int SortOrder { get; set; }

    }
}

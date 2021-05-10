using Bshoes.ViewModel.Catalog.Product;
using Bshoes.ViewModel.Catalog.ProductImage;
using Bshoes.ViewModel.Common;
using Bshoes.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bshoes.Service.Catalog.Products
{
    
  public interface IProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<ProductVm> GetProductById ( int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productID, int newStock);
        Task AddViewCout(int productId);
        Task<PageResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);

        Task<PageResult<ProductVm>> GetAllByCategoryId(GetPublicProductPagingRequest request);

      //  Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request);

        Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take);

        Task<List<ProductVm>> GetLatestProducts(string languageId, int take);

    }
}

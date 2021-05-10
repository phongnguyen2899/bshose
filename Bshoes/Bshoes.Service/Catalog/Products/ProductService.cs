using Bshoes.ViewModel.Catalog.Product;
using Bshoes.ViewModel.Catalog.ProductImage;
using Bshoes.ViewModel.Common;
using Bshoes.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Bshoes.Data.Entiti;
using Microsoft.EntityFrameworkCore;
using Bshoes.Data.EF;
using System.Linq;

namespace Bshoes.Service.Catalog.Products
{
    public class ProductService : IProductService
    {
        public readonly dbcontext _dbcontext;
        public ProductService(dbcontext dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public Task<int> AddImage(int productId, ProductImageCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task AddViewCout(int productId)
        {
            var product = await _dbcontext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            product.ViewCount++;
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            Product product = new Product()
            {
                Name = request.Name,
                Decription = request.Decription,
                Price = request.Price,
                OniginalPrice = request.OniginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                CategoryId = request.cateoryId
            };
            _dbcontext.Products.Add(product);


           return await _dbcontext.SaveChangesAsync();
        }

        public async Task<int> Delete(int productId)
        {
            var product =await _dbcontext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            _dbcontext.Products.Remove(product);
            return await _dbcontext.SaveChangesAsync();
        }

        public Task<PageResult<ProductVm>> GetAllByCategoryId(GetPublicProductPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PageResult<ProductVm>> GetAllPaging(GetManageProductPagingRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take)
        {
            throw new NotImplementedException();
        }

        public Task<ProductImageViewModel> GetImageById(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductVm>> GetLatestProducts(string languageId, int take)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductVm> GetProductById(int productId)
        {
            var query =await _dbcontext.Products.FirstOrDefaultAsync(x => x.Id == productId);
            ProductVm productVm = new ProductVm()
            {
                Id = query.Id,
                Name = query.Name,
                Decription = query.Decription,
                OniginalPrice = query.OniginalPrice,
                Price = query.Price,
                Stock = query.Stock,
                ViewCount = query.ViewCount
            };

            return  productVm;
        }

        public Task<int> RemoveImage(int imageId)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(ProductUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateStock(int productID, int newStock)
        {
            throw new NotImplementedException();
        }
    }
}

using Bshoes.Data.EF;
using Bshoes.Service.Catalog.Products;
using Bshoes.ViewModel.Catalog.Product;
using Bshoes.ViewModel.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bshoes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly dbcontext _dbcontext;
        public readonly IProductService _productService;
        public ProductController(dbcontext dbcontext,IProductService productService)
        {
            this._dbcontext = dbcontext;
            this._productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var productId = await _productService.Create(request);
            if (productId == 0) return BadRequest();

            return Ok(productId);
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("{productId}")]
        public async Task<IActionResult> GetbyproductId(int productId)
        {
            var list = await _productService.GetProductById(productId);
            return Ok(list);
        }
    }
}

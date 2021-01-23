using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Core.Entities;
using Infrastructure.Data;
using Core.Interfaces;

namespace API.Controllers
{


    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProductsAsync()
        {
            var products = await _repo.GetProductsAsync();
            if(products == null){
                return NotFound();
            }
            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
        {
            var product = await _repo.GetProductByIdAsync(id);
            if(product == null){
                return NotFound();
            }
            return Ok(product);
        }
    }
}
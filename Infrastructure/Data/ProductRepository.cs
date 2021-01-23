using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Entities;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _storeContext;
        public ProductRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            var result = await _storeContext.Products.AddAsync(product);
            await _storeContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProductBrand> CreateProductBrandAsync(ProductBrand productBrand)
        {
            var result = await _storeContext.ProductBrands.AddAsync(productBrand);
            await _storeContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<ProductType> CreateProductTypeAsync(ProductType productType)
        {
            var result = await _storeContext.ProductTypes.AddAsync(productType);
            await _storeContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteProductAsync(int id)
        {
            var result = await _storeContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);

            if (result != null)
            {
                _storeContext.Products.Remove(result);
                await _storeContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProductBrandAsync(int id)
        {  
            var result = await _storeContext.ProductBrands
                .FirstOrDefaultAsync(p => p.Id == id);

            if (result != null)
            {
                _storeContext.ProductBrands.Remove(result);
                await _storeContext.SaveChangesAsync();
            }
        }

        public async Task DeleteProductTypeAsync(int id)
        {  var result = await _storeContext.ProductTypes
                .FirstOrDefaultAsync(p => p.Id == id);

            if (result != null)
            {
                _storeContext.ProductTypes.Remove(result);
                await _storeContext.SaveChangesAsync();
            }
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _storeContext.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _storeContext.Products
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType).FirstOrDefaultAsync(p=>p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _storeContext.Products
                .Include(p=>p.ProductBrand)
                .Include(p=>p.ProductType)
                .ToListAsync();
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypesAsync()
        {
            return await _storeContext.ProductTypes.ToListAsync();
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var result = await _storeContext.Products
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (result != null)
            {
                result.Name = product.Name;
                result.Description = product.Description;
                result.Price = product.Price;
                result.UPC = product.UPC;
                result.SalePrice = product.SalePrice;                
                result.NetWeight = product.NetWeight;            
                result.PictureUrl = product.PictureUrl;
                result.ProductBrandId = product.ProductBrandId;
                result.ProductTypeId = product.ProductTypeId;
                await _storeContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<ProductBrand> UpdateProductBrandAsync(ProductBrand productBrand)
        {
            var result = await _storeContext.ProductBrands
                .FirstOrDefaultAsync(p => p.Id == productBrand.Id);

            if (result != null)
            {
                result.Name = productBrand.Name;
                await _storeContext.SaveChangesAsync();
                return result;
            }

            return null;
        }

        public async Task<ProductType> UpdateProductTypeAsync(ProductType productType)
        {  
            var result = await _storeContext.ProductTypes
                .FirstOrDefaultAsync(p => p.Id == productType.Id);

            if (result != null)
            {
                result.Name = productType.Name;
                await _storeContext.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}

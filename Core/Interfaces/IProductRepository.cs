using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
         Task<Product> GetProductByIdAsync(int id);
         Task<IReadOnlyList<Product>> GetProductsAsync();
         Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
         Task<IReadOnlyList<ProductType>> GetProductTypesAsync();

         Task<Product> CreateProductAsync(Product product);
         Task<ProductBrand> CreateProductBrandAsync(ProductBrand productBrand);
         Task<ProductType> CreateProductTypeAsync(ProductType productType);
         
         Task<Product> UpdateProductAsync(Product product);
         Task<ProductBrand> UpdateProductBrandAsync(ProductBrand productBrand);
         Task<ProductType> UpdateProductTypeAsync(ProductType productType);

         Task DeleteProductAsync(int id);
         Task DeleteProductBrandAsync(int id);
         Task DeleteProductTypeAsync(int id);
        

    }
}
using Core.Entities;

namespace Core.Specification
{
    public class ProductsWithTypesAndBrandsSpecification: BaseSpecification<Product>
    {
        public ProductsWithTypesAndBrandsSpecification(ProductSpecParams specParams):base(x =>
            (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search)) &&
            (!specParams.BrandId.HasValue || x.ProductBrandId == specParams.BrandId) &&
            (!specParams.TypeId.HasValue || x.ProductTypeId == specParams.TypeId)
        ){
            AddIncludes(x => x.ProductType);
            AddOrderBy(x => x.Name);
            if(!string.IsNullOrEmpty(specParams.Sort)){
                switch(specParams.Sort){
                    case  "priceAsc":
                    AddOrderBy(p => p.SalePrice ?? p.Price);
                    break;
                    case  "priceDesc":
                    AddOrderByDescending(p => p.SalePrice ?? p.Price);
                    break;
                    case  "nameAsc":
                    AddOrderBy(p => p.Name);
                    break;
                    case  "nameDesc":
                    AddOrderByDescending(p => p.Name);
                    break;
                }
            }

        }
        
    }
}
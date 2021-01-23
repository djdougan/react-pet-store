using System.Security.AccessControl;
namespace Core.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Http;
    public class Product: BaseEntity
    {
        public string Name { get; set;}
        public string Description { get; set;}
        public string UPC {get; set;}
        public string NetWeight{get; set;}
        public decimal Price{ get; set;}
        public decimal? SalePrice{ get; set;}
        public string PictureUrl{get; set;}
        
        [NotMapped]
        public IFormFile Image{get; set;}
        public ProductType ProductType{get; set;}
        public int ProductTypeId{get; set;}
        public ProductBrand ProductBrand{get; set;}
        public int ProductBrandId{get; set;}



        
    }
}
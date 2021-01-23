
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Core.Entities;
using Infrastructure.Data;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context, ILoggerFactory loggerFactory){

            try{
                if(!context.ProductTypes.Any()){
                    var typeData = File.ReadAllText("../Infrastructure/Data/SeedData/product-type.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typeData);
                    foreach( var item in types){
                        context.ProductTypes.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if(!context.ProductBrands.Any()){
                    var brandData = File.ReadAllText("../Infrastructure//Data/SeedData/product-brand.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandData);
                    foreach( var item in brands){
                        context.ProductBrands.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
                if(!context.Products.Any()){
                    var productData = File.ReadAllText("../Infrastructure//Data/SeedData/product.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    foreach( var item in products){
                        context.Products.Add(item);
                    }
                    await context.SaveChangesAsync();
                }

            }catch(Exception ex){
                var logger = loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
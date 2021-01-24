using System;
using Core.Entities;
using Infrastructure.Data;
using Xunit;
using Moq;  
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Core.Interfaces;
using API.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Infrastructure.Data.Configuration;
using System.Linq;

namespace PetStoreApiTests
{
    public class ProductTests
    {
        //Create In Memory Database

               [Fact]
        public async Task GetsProductsAsyncTest()
        {
            // // Arrange
            // var mockRepo = new Mock<IProductRepository>();
            // mockRepo.Setup(repo => repo.GetProductsAsync()).Returns(Task.FromResult(GetTestSessions() as IReadOnlyList<Product>));
            // var controller = new ProductsController(mockRepo.Object);
            // // // Act
            // var result = await controller.GetProductsAsync();
            // Console.WriteLine("XXX-31" + (ObjectResult)result);
            // Console.WriteLine("XXX-32" + result.());

            // // // Assert
            // var actionResult = Assert.IsType<ActionResult<IReadOnlyList<Product>>>(result);
            // Console.WriteLine("xxx-35" + actionResult);
            // var model = Assert.IsAssignableFrom<IReadOnlyList<Product>>(
            //     actionResult.Value);
            // Console.WriteLine("XXX-38"+model);
            // // Assert.Equal(2, model.Count());
        }

        // [Fact]
        // public async Task IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        // {
        //     // Arrange
        //     var mockRepo = new Mock<IBrainstormSessionRepository>();
        //     mockRepo.Setup(repo => repo.ListAsync()).Returns(Task.FromResult(GetTestSessions()));
        //     var controller = new HomeController(mockRepo.Object);
        //     controller.ModelState.AddModelError("SessionName", "Required");
        //     var newSession = new HomeController.NewSessionModel();

        //     // Act
        //     var result = await controller.Index(newSession);

        //     // Assert
        //     var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
        //     Assert.IsType<SerializableError>(badRequestResult.Value);
        // }

        // [Fact]
        // public async Task IndexPost_ReturnsARedirectAndAddsSession_WhenModelStateIsValid()
        // {
        //     // Arrange
        //     var mockRepo = new Mock<IBrainstormSessionRepository>();
        //     mockRepo.Setup(repo => repo.AddAsync(It.IsAny<BrainstormSession>()))
        //         .Returns(Task.CompletedTask)
        //         .Verifiable();
        //     var controller = new HomeController(mockRepo.Object);
        //     var newSession = new HomeController.NewSessionModel()
        //     {
        //         SessionName = "Test Name"
        //     };

        //     // Act
        //     var result = await controller.Index(newSession);

        //     // Assert
        //     var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
        //     Assert.Null(redirectToActionResult.ControllerName);
        //     Assert.Equal("Index", redirectToActionResult.ActionName);
        //     mockRepo.Verify();
        // }

        private static List<Product> GetTestSessions()
        {
            var products = new List<Product>{
                new Product{
                    Id = 1,
                    Name ="Test 1",
                    Description = "Test Description 1",
                    UPC = "123456",
                    NetWeight ="1kg",
                    Price = 1.00M,
                    SalePrice = null,
                    PictureUrl = "test1.jpg",
                    ProductTypeId =1,
                    ProductBrandId = 1

                  },
                new Product{
                    Id = 2,
                    Name ="Test 2",
                    Description = "Test Description 2",
                    UPC = "654321",
                    NetWeight ="2kg",
                    Price = 2.00M,
                    SalePrice = 1.00M,
                    PictureUrl = "test2.jpg",
                    ProductTypeId = 2,
                    ProductBrandId = 2

                  }

            };
            return products;
        }

    }
}

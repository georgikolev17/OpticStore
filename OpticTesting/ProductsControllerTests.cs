using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AppointmentScheduler.Controllers;
using Optik.Models.ViewModels;
using AppointmentScheduler.Models;
using Optik.Services;
using NuGet.ContentModel;

namespace Optik.Testing
{
    public class ProductsControllerTests
    {
        [Fact]
        public void Index_Post_ReturnsFilteredProductsInViewModel()
        {
            // Arrange
            var mockProductsService = new Mock<IProductsService>();

            var sampleProducts = new List<Product>
            {
                new Product { Id = 1, Title = "Cool Glasses", Description = "Stylish", Price = 130 }
            };

            mockProductsService
                .Setup(service => service.GetSearchedProducts(100, 150, "Glasses"))
                .Returns(sampleProducts);

            var controller = new ProductsController(null, mockProductsService.Object);

            var inputModel = new ProductsViewModel
            {
                StartPrice = 100,
                EndPrice = 150,
                searchQuery = "Glasses"
            };

            // Act
            var result = controller.Index(inputModel) as ViewResult;

            // Assert
            Assert.NotNull(result);
            var returnedModel = result.Model as ProductsViewModel;
            Assert.NotNull(returnedModel);
            Assert.Single(returnedModel.Products);
            Assert.Equal("Cool Glasses", ((List<Product>)returnedModel.Products)[0].Title);
        }
    }
}

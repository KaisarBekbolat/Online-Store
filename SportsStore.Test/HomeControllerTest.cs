using System;
using Moq;
using SporteStore___2nd_try.Models;
using SporteStore___2nd_try.Controllers;
using System.Net;
using SporteStore___2nd_try.Models.ViewModels;
using System.Diagnostics.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Test;

public class HomeControllerTest
{
    [Fact]
    public void Can_Send_Pignation_View_Model(){

        // Arrange

        Mock<IStoreRepository> mockRepo = new Mock<IStoreRepository>();
        mockRepo.SetupGet(x=>x.Products).Returns(new List<Product>{
            new Product {ProductId = 1, Name = "P1"},
            new Product {ProductId = 2, Name = "P2"},
            new Product {ProductId = 3, Name = "P3"},
            new Product {ProductId = 4, Name = "P4"},
            new Product {ProductId = 5, Name = "P5"}
        });

        // Act
        HomeController controller = new HomeController(mockRepo.Object){PageSize=3};

        ProductsListViewModel product_Pignation = controller.Index(null, 2).Model as ProductsListViewModel ?? new();

        // Act
        Assert.Equal(new List<Product>{
            new Product {ProductId = 4, Name = "P4"},
            new Product {ProductId = 5, Name = "P5"}
        }, product_Pignation.Products, (Product x, Product y)=>{return x.ProductId==y.ProductId;});
    }

    [Fact]
    public void Can_Filter_Products(){
        //Arrange
        Mock<IStoreRepository> mock = new Mock<IStoreRepository>();

        mock.Setup(x=>x.Products).Returns(new List<Product>{
            new Product
                {
                    Name = "Kayak",
                    Description =
                            "A boat for one person",
                    Category = "Watersports",
                    Price = 275
                },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description =
                          "Give your playing field a professional touch",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Category = "Chess",
                        Price = 16
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description =
                          "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Description = "A fun game for the family",
                        Category = "Chess",
                        Price = 75
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200
                    }
        });

        //Act
        HomeController controller = new HomeController(mock.Object);

        IEnumerable<Product> result = (controller.Index("Soccer", 1).Model as ProductsListViewModel ?? new()).Products.ToArray();

        //Assert
        Assert.Equal(3, result.Count());
    }
}

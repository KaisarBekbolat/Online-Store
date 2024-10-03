using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using SporteStore___2nd_try.Components;
using SporteStore___2nd_try.Models;

namespace SportsStore.Test;

public class NavigationMenuViewComponentTests
{
    [Fact]
    public void MenuCategories()
    {

        //Arrange
        Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
        mock.Setup(x => x.Products).Returns(new List<Product>(){
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
        NavigationMenuViewComponent viewComponent = new NavigationMenuViewComponent(mock.Object);

        string[] result = ((IEnumerable<string>?)(viewComponent.Invoke() 
        as ViewViewComponentResult)?.ViewData?.Model ?? Enumerable.Empty<string>()).ToArray();

        // Assert
        Assert.Equal(3, result.Length);
    }
}

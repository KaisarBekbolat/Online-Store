using System;
using SporteStore___2nd_try.Models;

namespace SportsStore.Test;

public class CartTests
{
    [Fact]
    public void Can_Add_New_Lines(){
        // Arrange
        Product p1 = new Product(){ProductId = 1, Name="p1"};
        Product p2 = new Product(){ProductId = 2, Name="p2"};

        Cart target = new Cart();

        // Act
        target.AddItem(p1, 3);
        target.AddItem(p2, 4);

        CartLine[] results = target.Lines.ToArray();

        // Assert
        Assert.Equal(2, results.Length);
        Assert.Equal(p1, results[0].Product);
        Assert.Equal(p2, results[1].Product);
    }

    [Fact]
    public void Can_Add_Quantity_For_Existing_Lines(){
        //Arrange
        Product p1 = new Product() { ProductId = 1, Name = "p1" };
        Cart target = new Cart();

        //Act
        target.AddItem(p1, 3);
        target.AddItem(p1, 2);

        //Assert
        Assert.Equal(5, target.Lines[0].Quantity);
    }

    [Fact]
    public void Can_Remove_Line(){
        // Arrange
        Product p1 = new Product(){ProductId=1, Name="p1"};
        Product p2 = new Product(){ProductId=2, Name="p2"};

        Cart target = new Cart();
        target.AddItem(p1, 4);
        target.AddItem(p2, 5);

        // Act
        target.RemoveItem(p1);
        CartLine[] result = target.Lines.ToArray();

        // Assert
        Assert.Single(result);
        Assert.Equal(5, result[0].Quantity);
    }

    [Fact]
    public void Calculate_Total_Price(){
        // Arrange
        Product p1 = new Product(){ProductId=1, Name="p1", Price=100M};
        Product p2 = new Product(){ProductId=2, Name="p2", Price=50M};

        Cart target = new Cart();

        // Act
        target.AddItem(p1, 4);
        target.AddItem(p2, 6);

        // Assert
        Assert.Equal(700M, target.ComputeTotalValue());
    }
}

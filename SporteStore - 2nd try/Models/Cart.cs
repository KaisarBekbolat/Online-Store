using System;

namespace SporteStore___2nd_try.Models;

public class Cart
{
    public List<CartLine> Lines{get;set;} = new List<CartLine>();  // TODO as here you forgot to write "{get;set;}"
                                                                   // that was the result of WHY there is no data being added to CART

    public void AddItem(Product product, int quantity){
        CartLine? line = Lines.Where(x=>x.Product.ProductId==product.ProductId).FirstOrDefault();

        if(line==null){
            Lines.Add(new CartLine(){
                Product = product,
                Quantity = quantity
            });
        }
        else{
            line.Quantity += quantity;
        }
    }

    public void RemoveItem(Product product){
        Lines.RemoveAll(x=>x.Product.ProductId==product.ProductId);
    }

    public decimal ComputeTotalValue(){
        return Lines.Select(x=>x.Product.Price*x.Quantity).Sum();
    }
    public void Clear() => Lines.Clear();
}

public class CartLine
{ //The Cart class uses the CartLine class, defined in the same file, to represent a product selected by the customer and the quantity the user wants to buy
    public int CartLineID{get;set;}
    public Product Product{get;set;}=new();
    public int Quantity{get;set;}
}

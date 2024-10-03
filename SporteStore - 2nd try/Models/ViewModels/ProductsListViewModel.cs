using System;

namespace SporteStore___2nd_try.Models.ViewModels;

public class ProductsListViewModel
{
    public IEnumerable<Product> Products {get;set;}=Enumerable.Empty<Product>();
    public PagingInfo PagingInfo{get;set;} = new PagingInfo();
    public string? CurrentCategory{get;set;}
}

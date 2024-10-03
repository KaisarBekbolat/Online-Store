using System;
using Microsoft.AspNetCore.Mvc;
using SporteStore___2nd_try.Models;
using SporteStore___2nd_try.Models.ViewModels;

namespace SporteStore___2nd_try.Controllers;

public class HomeController : Controller
{
    private IStoreRepository _repo;
    public int PageSize = 4;
    public HomeController(IStoreRepository repo){
        _repo =repo;
    }

    [HttpGet]
    public ViewResult Index(string? category, int productPage=1){

        return View(new ProductsListViewModel(){
            Products = _repo.Products
                .Where(x=> x.Category==category || category==null)  // returns object if Category was not specified or if category was matched
                .OrderBy(x=>x.ProductId)
                .Skip((productPage-1)*PageSize).Take(PageSize).ToList(),
            PagingInfo = new PagingInfo{
                TotalItems = (category == null
                    ? _repo.Products.Count()
                    : _repo.Products.Where(e =>e.Category == category).Count())
                ,
                ItemsPerPage = PageSize,
                CurrentPage = productPage
            },
            CurrentCategory = category  // Assign current category as "clicked" and returns to VIEW
        });
    }
}
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SporteStore___2nd_try.Models;

namespace SporteStore___2nd_try.Components;

public class NavigationMenuViewComponent : ViewComponent
{
    private IStoreRepository _repo;

    public NavigationMenuViewComponent(IStoreRepository repository){
        _repo = repository;
    }
    public IViewComponentResult Invoke(){
        ViewBag.SelectedCategory = RouteData.Values["Category"];  // TODO this code is responsible for identifying SELECTED category
        return View(_repo.Products.Select(x=>x.Category).Distinct().OrderBy(x=>x));
    }
}

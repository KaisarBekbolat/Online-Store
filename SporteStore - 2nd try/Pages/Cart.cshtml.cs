using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SporteStore___2nd_try.Infrastructure;
using SporteStore___2nd_try.Models;

namespace SporteStore___2nd_try.Pages
{
    public class CartModel : PageModel
    {
        private IStoreRepository _repo;

        public CartModel(IStoreRepository repository){
            _repo = repository;
        }
        public Cart? Cart{get;set;}
        public string ReturnUrl{get;set;}="/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product? product = _repo.Products
            .FirstOrDefault(p => p.ProductId == productId);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart")
                ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl }); // TODO identify what is the PURPOSE and HOW URL extension works in Infrastucture folder
        }

    }
}

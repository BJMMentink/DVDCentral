using BJM.DVDCentral.UI.Extentions;
using BJM.DVDCentral.UI.Models;
using BJM.DVDCentral.UI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BJM.ProgDec.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        ShoppingCart cart;
        // GET: ShoppingCartController
        public ActionResult Index()
        {
            ViewBag.Title = "Shopping Cart 2";
            cart = GetShoppingCart();
            return View(cart);
        }

        public ShoppingCart GetShoppingCart()
        {

            if (HttpContext.Session.GetObject<ShoppingCart>("cart") != null)
            {
                return HttpContext.Session.GetObject<ShoppingCart>("cart");
            }
            else
            {
                return new ShoppingCart();
            }
        }

        public IActionResult Remove(int id)
        {
            cart = GetShoppingCart();
            Movie movie = cart.Items.FirstOrDefault(i => i.Id == id);
            ShoppingCartManager.Remove(cart, movie);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add(int id)
        {
            cart = GetShoppingCart();
            Movie movie = MovieManager.LoadById(id);
            ShoppingCartManager.Add(cart, movie);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction(nameof(Index), "Movie");
        }
        public IActionResult CheckOut()
        {
            if (Authenticate.IsAuthenticated(HttpContext))
            {
                ViewBag.Title = "Shopping Cart";
                cart = GetShoppingCart();
                //ShoppingCartManager.Checkout(cart);
                HttpContext.Session.SetObject("cart", null);

                return View(cart);
            }
            else
            {
                var redirect = RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
                return redirect;
            }

        }

        public ActionResult AssignToCustomer()
        {

            var user = HttpContext.Session.GetObject<User>("user");
            CustomerViewModel customerViewModel = new CustomerViewModel();
            Customer customer = new Customer();
            var shoppingCart = GetShoppingCart();
            var cartList = new List<ShoppingCart>();
            cartList.Add(shoppingCart);
            customerViewModel.Cart = cartList;
            customerViewModel.Customers = CustomerManager.Load();
            if (Authenticate.IsAuthenticated(HttpContext))
            {

                customerViewModel.UserId = user.Id;
            }
            else
            {
                var redirect = RedirectToAction("Login", "User", new { returnUrl = UriHelper.GetDisplayUrl(HttpContext.Request) });
                return redirect;
            }
            
            if (customerViewModel.Customers.Any())
            {
                customerViewModel.CustomerId = customerViewModel.Customers.First().Id;
                customerViewModel.UserId = customerViewModel.Customers.First().UserId;
                HttpContext.Session.SetObject("customerViewModel", customerViewModel);
                ViewData["ReturnUrl"] = UriHelper.GetDisplayUrl(HttpContext.Request);
                return View(customerViewModel);
            }
            else
            {
                return View(customerViewModel);
            }


        }
        [HttpPost]
        public ActionResult AssignToCustomer(CustomerViewModel customerViewModel)
        {
            try
            {
               
                    //var user = HttpContext.Session.GetObject<User>("user");
                    //customerViewModel.UserId = user.Id;

                    var shoppingCart = HttpContext.Session.GetObject<ShoppingCart>("cart");
                    customerViewModel.Cart.Add(shoppingCart);
                    ShoppingCartManager.Checkout(shoppingCart, customerViewModel.UserId, customerViewModel.CustomerId);


                    return RedirectToAction(nameof(CheckOut));
                
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}

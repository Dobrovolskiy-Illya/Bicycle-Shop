using Bisycles.Extensions;
using Bisycles.Models;
using Bisycles.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bisycles.Controllers
{
    public class CartController : Controller
    {
        BicycleContext context;
        public CartController (BicycleContext context)
        {
            this.context = context;
        }
        public IActionResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            }); 
        }

        public IActionResult AddToCart (int bicycleId, string returnUrl)
        {
            Bicycle bicycle = context.Bicycle.FirstOrDefault(x => x.BicycleId == bicycleId);
            if (bicycle != null)
            {
                var cart = GetCart();
                cart.AddItem(bicycle, 1);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult RemoveFromCart ( int bicycleId, string returnUrl)
        {
            Bicycle bicycle = context.Bicycle.FirstOrDefault(x => x.BicycleId == bicycleId);
            if ( bicycle != null)
            {
                var cart = GetCart();
                cart.RemoveLine(bicycle);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult RemoveOneFromCart(int bicycleId, string returnUrl)
        {
            Bicycle bicycle = context.Bicycle.FirstOrDefault(x => x.BicycleId == bicycleId);
            if (bicycle != null)
            {
                var cart = GetCart();
                cart.RemoveOneItem(bicycle);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public IActionResult AddOneItemToCart(int bicycleId, string returnUrl)
        {
            Bicycle bicycle = context.Bicycle.FirstOrDefault(x => x.BicycleId == bicycleId);
            if (bicycle != null)
            {
                var cart = GetCart();
                cart.AddOneItem(bicycle);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        private Cart GetCart()
        {
            Cart cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            if (cart == null)
            {
                cart = new Cart();
                HttpContext.Session.SetObjectAsJson("Cart",cart);
            }
            return cart;
        }

        public Cart DeleteCart()
        {
            Cart cart = HttpContext.Session.GetObjectFromJson<Cart>("Cart");
            cart.Clear();
            return cart;
        }
    }
}

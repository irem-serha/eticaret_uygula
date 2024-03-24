﻿using eticaret_uygula.Data;
using eticaret_uygula.Dto;
using eticaret_uygula.Models;
using eticaret_uygula.Oturum;
using Microsoft.AspNetCore.Mvc;

namespace eticaret_uygula.Component
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<CartItem> items = HttpContext.Session.GetJson<List<CartItem>>("Cart")?? new List<CartItem>();
            CartViewModel cartvm = new()
            {
                CartItems = items,
                GrandTotal = items.Sum(x => x.Quantity * x.Price)
            };
            return View(cartvm);
        }
        public async Task<IActionResult> Add(int id)
        {
            Products product = _context.Products.Find(id);
            List<CartItem> items = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem = items.FirstOrDefault(x => x.ProductId == id);
            if (cartItem == null)
            {
                items.Add(new CartItem(product));
            }
            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", items);
            TempData["Mesaj"] = "Ürün sepete eklenmiştir.";

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> decrease(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            CartItem cartItem=cart.Where(c=>c.ProductId == id).FirstOrDefault();
            if (cartItem.Quantity>1)
            {
                cartItem.Quantity-= 1;
            }
            else
            {
                cart.RemoveAll(c => c.ProductId == id);
            }
            if(cart.Count>0)
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Mesaj"] = "Ürün sepetten silindi.";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
            cart.RemoveAll(c => c.ProductId == id);
            if(cart.Count>0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            TempData["Mesaj"] = "Ürün Silindi";
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Clear(int id)
        {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
        }
    }
}

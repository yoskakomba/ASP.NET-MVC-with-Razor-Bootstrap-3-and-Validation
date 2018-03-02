using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onboard1.Models;

namespace Onboard1.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        public ActionResult GetSalesList()
        {
            List<MySale> sale;
            using (var db = new Onboard1DbContext())
            {
                sale = db.ProductSolds.Select(x => new MySale
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    CustomerName = x.Customer.Name,
                    StoreName = x.Store.Name,
                    DateSold = x.DateSold
                }).ToList();

                
            }
            return View(sale);
        }


        // CREATE NEW PRODUCT SOLD/SALES
        public ActionResult Create()
        {
            using (var db = new Onboard1DbContext())
            {
                ViewBag.ProductId = db.Products.Select(x => new { x.Id, x.Name }).ToList();
                ViewBag.CustomerId = db.Customers.Select(x => new { x.Id, x.Name }).ToList();
                ViewBag.StoreId = db.Stores.Select(x => new { x.Id, x.Name }).ToList();

                return View();
            }
        }

        [HttpPost]
        public ActionResult Create(ProductSold prods)
        {
            using (var db = new Onboard1DbContext())
            {
                if (ModelState.IsValid)
                {
                    db.ProductSolds.Add(prods);
                    db.SaveChanges();
                    return RedirectToAction("GetSalesList");
                }

                ViewBag.ProductId = db.Products.Select(x => new { x.Id, x.Name }).ToList();
                ViewBag.CustomerId = db.Customers.Select(x => new { x.Id, x.Name }).ToList();
                ViewBag.StoreId = db.Stores.Select(x => new { x.Id, x.Name }).ToList();
                return View(prods);
            }
        }


        public ActionResult Edit(int Id)
        {
            using (var db = new Onboard1DbContext())
            {
                var sale = db.ProductSolds.FirstOrDefault(x => x.Id == Id);
                
                ViewBag.ProductId = db.Products.Select(x => new { x.Id, x.Name }).ToList();
                ViewBag.CustomerId = db.Customers.Select(x => new { x.Id, x.Name }).ToList();
                ViewBag.StoreId = db.Stores.Select(x => new { x.Id, x.Name }).ToList();

                return View(sale);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductSold prods)
        {
            using (var db = new Onboard1DbContext())
            {
                if (ModelState.IsValid)
                {
                    var sale = db.ProductSolds.FirstOrDefault(x => x.Id == prods.Id);
                    if (sale != null)
                    {
                        sale.ProductId = prods.ProductId;
                        sale.CustomerId = prods.CustomerId;
                        sale.StoreId = prods.StoreId;
                        sale.DateSold = prods.DateSold;
                    }

                    db.SaveChanges();
                    return RedirectToAction("GetSalesList");
                }

                
                ViewBag.ProductId = db.Products.Select(x => new { x.Id, x.Name }).ToList();
                ViewBag.CustomerId = db.Customers.Select(x => new { x.Id, x.Name }).ToList();
                ViewBag.StoreId = db.Stores.Select(x => new { x.Id, x.Name }).ToList();
                return View(prods);
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new Onboard1DbContext())
            {

                var sold = db.ProductSolds.Where(x => x.Id == id).Select(x => new MyProductSold
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    CustomerName = x.Customer.Name,
                    StoreName = x.Store.Name,
                    DateSold = x.DateSold

                }).FirstOrDefault();
                return View(sold);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var sold = db.ProductSolds.Where(x => x.Id == id).Select(x => new MyProductSold
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    CustomerName = x.Customer.Name,
                    StoreName = x.Store.Name,
                    DateSold = x.DateSold

                }).FirstOrDefault();
                return View(sold);
            }
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var productsold = db.ProductSolds.FirstOrDefault(x => x.Id == id);
                if (productsold != null) db.ProductSolds.Remove(productsold); 
     
                db.SaveChanges();
                return RedirectToAction("GetSalesList");
            }
        }

        //public ActionResult Delete(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
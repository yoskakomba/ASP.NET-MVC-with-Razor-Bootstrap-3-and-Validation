using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onboard1.Models;

namespace Onboard1.Controllers
{
    public class ProductController : Controller
    {
        
        // GET: Product
        public ActionResult Index()
        {
            using (var db = new Onboard1DbContext())
            {
                var product = db.Products.Select(x => new MyProduct
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price
                }).ToList();

                return View(product);
            }
        }

        // CREATE 
        public ActionResult Create()
        {
            return View();
        }

        // GET POST
        [HttpPost]
        public ActionResult Create(Product prod)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Onboard1DbContext())
                {
                    db.Products.Add(prod);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        // EDIT 
        public ActionResult Edit(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var prod = db.Products.FirstOrDefault(x => x.Id == id);
                return View(prod);
            }
        }

        // GET POST: EDIT
        [HttpPost]
        public ActionResult Edit(Product prod)
        {
            using (var db = new Onboard1DbContext())
            {
                var producti = db.Products.FirstOrDefault(x => x.Id == prod.Id);
                producti.Id = prod.Id;
                producti.Name = prod.Name;
                producti.Price = prod.Price;
                db.SaveChanges();
                return RedirectToAction("Index");

                //return View(prod);
            }
            
        }


        // GET DETAILS
        public ActionResult Details(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var prod = db.Products.FirstOrDefault(x => x.Id == id);
                return View(prod);
            }
        }

        // DELETE
        public ActionResult Delete(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var prod = db.Products.FirstOrDefault(x => x.Id == id);
                return View(prod);
            }
        }

        // DELETE: POST
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var prod = db.Products.FirstOrDefault(x => x.Id == id);
                var prodsold = db.ProductSolds.FirstOrDefault(x => x.Id == id);
                var prodid = db.ProductSolds.FirstOrDefault(x => x.ProductId == id);

                if (prod != null) db.Products.Remove(prod);
                if (prodsold != null) db.ProductSolds.Remove(prodsold);
                if (prodid != null) db.ProductSolds.Remove(prodid);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }
}
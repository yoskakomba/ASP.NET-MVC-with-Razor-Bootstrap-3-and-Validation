using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onboard1.Models;

namespace Onboard1.Controllers
{
    public class StoreController : Controller
    {


        // GET: Store list
        public ActionResult Index()
        {
            using (var db = new Onboard1DbContext())
            {
                var store = db.Stores.Select(x => new MyStore
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address
                }).ToList();

                return View(store);
            }
        }

        // CREATE 
        public ActionResult Create()
        {
            return View();
        }

        // GET POST
        [HttpPost]
        public ActionResult Create(Store sto)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Onboard1DbContext())
                {
                    db.Stores.Add(sto);
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
                var stor = db.Stores.FirstOrDefault(x => x.Id == id);
                return View(stor);
            }
        }

        // GET POST: EDIT
        [HttpPost]
        public ActionResult Edit(Store stor)
        {
            using (var db = new Onboard1DbContext())
            {
                var stori = db.Stores.FirstOrDefault(x => x.Id == stor.Id);
                stori.Id = stor.Id;
                stori.Name = stor.Name;
                stori.Address = stor.Address;
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
                var stor = db.Stores.FirstOrDefault(x => x.Id == id);
                return View(stor);
            }
        }

        // DELETE
        public ActionResult Delete(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var stor = db.Stores.FirstOrDefault(x => x.Id == id);
                return View(stor);
            }
        }

        // DELETE: POST
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var stor = db.Stores.FirstOrDefault(x => x.Id == id);
                var prodsold = db.ProductSolds.FirstOrDefault(x => x.Id == id);
                var storeid = db.ProductSolds.FirstOrDefault(x => x.StoreId == id);

                if (stor != null) db.Stores.Remove(stor);
                if (prodsold != null) db.ProductSolds.Remove(prodsold);
                if (storeid != null) db.ProductSolds.Remove(storeid);

                db.SaveChanges();
                return RedirectToAction("Index");

            }
        }
    }

}
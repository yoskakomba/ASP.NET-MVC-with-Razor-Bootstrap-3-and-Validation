using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Onboard1.Models;

namespace Onboard1.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult GetCustomerList()
        {
            List<MyCustomer> custom;
            using (var db = new Onboard1DbContext())
            {
                custom = db.Customers.Select(x => new MyCustomer
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address
                }).ToList();
            }

            return View(custom);
        }

        // CREATE
        public ActionResult Create()
        {
            return View();
        }

        // GET POST
        [HttpPost]
        public ActionResult Create(Customer cust)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Onboard1DbContext())
                {
                    db.Customers.Add(cust);
                    db.SaveChanges();
                    return RedirectToAction("GetCustomerList");
                }
            }

            return View();
        }

        // EDIT 
        public ActionResult Edit(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var cust = db.Customers.FirstOrDefault(x => x.Id == id);
                return View(cust);
            }
        }

        // GET POST: EDIT
        [HttpPost]
        public ActionResult Edit(Customer cust)
        {
            using (var db = new Onboard1DbContext())
            {
                var custom = db.Customers.FirstOrDefault(x => x.Id == cust.Id);
                if (custom != null)
                {
                    custom.Id = cust.Id;
                    custom.Name = cust.Name;
                    custom.Address = cust.Address;
                }

                db.SaveChanges();
                return RedirectToAction("GetCustomerList");


            }

        }


        // GET DETAILS
        public ActionResult Details(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var cust = db.Customers.FirstOrDefault(x => x.Id == id);
                return View(cust);
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var custom = db.Customers.FirstOrDefault(x => x.Id == id);
                return View(custom);
            }
        }

        // DELETE: POST
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            using (var db = new Onboard1DbContext())
            {
                var custom = db.Customers.FirstOrDefault(x => x.Id == id);
                if (custom != null) db.Customers.Remove(custom);
                db.SaveChanges();
                return RedirectToAction("GetCustomerList");

            }
        }
    }
}
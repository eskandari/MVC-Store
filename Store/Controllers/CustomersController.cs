using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Store.Models;
using Store.Models.ViewModels;

namespace Store.Controllers
{
    public class CustomersController : Controller
    {
        private StoreContext db = new StoreContext();

        //
        // GET: /Customers/

        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Address).ToList();
            var customerVMList = new List<CustomerViewModel>();
            foreach (var c in customers)
            {
                customerVMList.Add(new CustomerViewModel { Id = c.Id, Name = c.Name, PhoneNumber = c.PhoneNumber, SSN = c.SSN, City = c.Address.City, Street = c.Address.Street, PostalCode = c.Address.PostalCode });
            }

            return View(customerVMList);
        }

        //
        // GET: /Customers/Details/5

        public ActionResult Details(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // GET: /Customers/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Customers/Create

        [HttpPost]
        public ActionResult Create(CustomerViewModel customerViewModel)
        {
            var address = new Address { City = customerViewModel.City,PostalCode=customerViewModel.PostalCode,Street=customerViewModel.Street};
            var customer = new Customer { Name = customerViewModel.Name, PhoneNumber = customerViewModel.PhoneNumber, SSN = customerViewModel.SSN , Address=address};
           
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customerViewModel);
        }

        //
        // GET: /Customers/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Addresses, "CustomerId", "City", customer.Id);
            return View(customer);
        }

        //
        // POST: /Customers/Edit/5

        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Addresses, "CustomerId", "City", customer.Id);
            return View(customer);
        }

        //
        // GET: /Customers/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Customers/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
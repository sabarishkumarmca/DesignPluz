using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DesignPluz.Models;

namespace DesignPluz.Controllers
{
    public class CustomersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

       
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var customers = db.Customers.Include(c => c.Genders);
            return View(await customers.ToListAsync());
        }

        
        [HttpGet] 
        public ActionResult Create()
        {
            ViewBag.genderId = new SelectList(db.Genders, "Id", "Gender");
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = await db.Customers.FindAsync(id);

            List<Addresses> addresses = await db.Addresses.Where(x => x.CustomerId == id).ToListAsync();

            if (customers == null)
            {
                return HttpNotFound();
            }

            ViewBag.genderId = new SelectList(db.Genders, "Id", "Gender", customers.genderId);

            ViewBag.AddressTypeId = new SelectList(db.AddressTypes, "id", "AddressType");

            CustomerViewModel customerViewModel = new CustomerViewModel();

            customerViewModel.Customers = customers;

            customerViewModel.Addresses = addresses;

            customerViewModel.genderId = customers.genderId;

            return View(customerViewModel);
        }
         
        
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = await db.Customers.FindAsync(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

         
        [HttpPost] 
        public async Task<ActionResult> DeleteCustomerDetails(int id)
        {
            List<Addresses> addresses = await db.Addresses.Where(x => x.CustomerId == id).ToListAsync();
            if(addresses.Count > 0)
            { 
                db.Addresses.RemoveRange(addresses);
                await db.SaveChangesAsync();
            }

            Customers customers = await db.Customers.FindAsync(id);
            db.Customers.Remove(customers);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //[HttpGet]
        public PartialViewResult DisplayNewAddress()
        {
            ViewBag.AddressTypeId = new SelectList(db.AddressTypes, "id", "AddressType");
            return PartialView("_PartialPage");
        }

        [HttpPost]
        public ActionResult CreateCustomers(Customers customer, List<Addresses> addresses)
        {
            db.Customers.Add(customer);
            db.SaveChanges();

            using (var db2 = new DatabaseContext())
            {
                foreach (Addresses addres in addresses)
                {
                    addres.CustomerId = customer.id;
                    db2.Addresses.Add(addres);
                }
                db2.SaveChanges();
            }
            //return View(customers);
            return View("Index");
        }
        [HttpPost]
        public ActionResult EditCustomers(Customers customer, List<Addresses> addresses)
        {
            db.Entry(customer).State = EntityState.Modified;
            db.SaveChanges();

            using (var db2 = new DatabaseContext())
            {
                foreach (Addresses addres in addresses)
                {
                    addres.CustomerId = customer.id;
                    if (addres.id > 0)
                    {
                        db.Entry(addres).State = EntityState.Modified;
                    }
                    else
                    {
                        db2.Addresses.Add(addres);
                    }
                    db2.SaveChanges();
                }

            }
            //return View(customers);
            return View("Index");
        }



        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

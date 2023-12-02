using CustomerServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerService.Controllers
{
    public class CustomerController : Controller
    {

        private readonly TTCSNEntities _context;

        public CustomerController()
        {
            _context = new TTCSNEntities();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var listOfData = _context.Customers.ToList();
            return View(listOfData);
        }


        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer model)
        {
           
            _context.Customers.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Index");
           
        }
        public ActionResult Edit()
        {
            return View();
        }
        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer model)
        {
            try
            {
                var data = _context.Customers.Where(x => x.customer_id == model.customer_id).FirstOrDefault();
                if (data != null)
                {

                    data.first_name = model.first_name;
                    data.last_name = model.last_name;
                    data.email = model.email;
                    data.phone = model.phone;
                    data.address = model.address;
                    _context.SaveChanges();
                }
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var data = _context.Customers.Where(x => x.customer_id == id).FirstOrDefault();
            _context.Customers.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("index");
        }
    }
}

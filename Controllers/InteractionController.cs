using CustomerServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CustomerServices.Controllers
{
    public class InteractionController : Controller
    {
        // GET: Interaction
        private readonly TTCSNEntities _context;

        public InteractionController()
        {
            _context = new TTCSNEntities();
        }
        public ActionResult Index()
        {

            var data = _context.Interactions.Include(x => x.Customer).ToList();
            return View(data);
            
        }

        // GET: Interaction/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Interaction/Create
        [HttpPost]
        public ActionResult Create(Interaction model)
        {
            try
            {
                _context.Interactions.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Interaction/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Interaction/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Interaction/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Interaction/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

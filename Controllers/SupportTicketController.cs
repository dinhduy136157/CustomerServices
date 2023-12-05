using CustomerServices.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CustomerServices.Controllers
{
    public class SupportTicketController : Controller
    {
        private readonly TTCSNEntities _context;
        // GET: SupportTicket
        public SupportTicketController()
        {
            _context = new TTCSNEntities();
        }
        public ActionResult Index()
        {
            var data = _context.Support_Tickets.Include(x => x.Customer).ToList();
            return View(data);
        }

        // GET: SupportTicket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupportTicket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupportTicket/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SupportTicket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SupportTicket/Edit/5
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

        // GET: SupportTicket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupportTicket/Delete/5
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

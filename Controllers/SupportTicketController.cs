using CustomerServices.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using Newtonsoft.Json;

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

        // GET: SupportTicket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupportTicket/Create
        [HttpPost]
        public ActionResult Create(Support_Tickets model)
        {
            try
            {
                _context.Support_Tickets.Add(model);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SupportTicket/Edit/5
        public ActionResult Edit()
        {
            return View();
        }

        // POST: SupportTicket/Edit/5
        [HttpPost]
        public ActionResult Edit(Support_Tickets model)
        {
            try
            {
                var data = _context.Support_Tickets.Where(x => x.ticket_id == model.ticket_id).FirstOrDefault();
                if(data != null)
                {
                    data.subject = model.subject;
                    data.description = model.description;
                    data.status = model.status;
                    data.updated_at = model.updated_at;
                    _context.SaveChanges();
                }
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
            var data = _context.Support_Tickets.Where(x=>x.ticket_id==id).FirstOrDefault();
            _context.Support_Tickets.Remove(data);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult GetStatus()
        {
            var statusArray = _context.Support_Tickets.Select(x => x.status).ToArray();

            return Json(statusArray, JsonRequestBehavior.AllowGet);
        }
        
        
    }
}

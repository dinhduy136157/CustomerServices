﻿using CustomerServices.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Entity.Migrations.Model;
using Newtonsoft.Json;
using System.Web.Helpers;

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
        [HttpGet]
        public ActionResult Reply(int id)
        {
            /*var data = _context.replies.Include(x => x.Support_Tickets).Where(x => x.ticket_id == id).FirstOrDefault();*/
            var data = _context.Support_Tickets.Where(x => x.ticket_id == id).FirstOrDefault();       
                return View(data);
        }
        [HttpPost]
        public ActionResult Reply(reply model)
        {
            /*------------------------ADD DATA TO REPLY TABLE----------------*/
            var supportTicket = _context.Support_Tickets.Where(x => x.ticket_id == model.ticket_id).FirstOrDefault();
            _context.replies.Add(model);
            supportTicket.status = "H";
            _context.SaveChanges();
            /*------------------------SEND EMAIL--------------------------*/
            /* var getEmail = model.Support_Tickets.Customer.email;*/
            string email = supportTicket.Customer.email;
            string toUserIs = email;
            string subject = "Đơn xử lý yêu cầu hỗ trợ của Khách hàng " + supportTicket.Customer.first_name + " " + supportTicket.Customer.last_name ;
            string body = "<h2>Chủ đề hỗ trợ: " + model.title + "</h2>" +
                         "<b> Cách xử lý: </b>" + model.content + "<br /> Trân trọng, " + model.staff + "!";
            WebMail.Send(toUserIs, subject, body, null, null, null, true, null, null, null, null, null, null);
            return RedirectToAction("Index");
        }
    }
}

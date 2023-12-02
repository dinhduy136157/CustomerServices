using CustomerServices.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CustomerServices.Controllers
{
    public class InteractionController : Controller
    {

        private readonly TTCSNEntities _context;

        public InteractionController()
        {
            _context = new TTCSNEntities();
        }
        public ActionResult Index()
        {   
            var data = (from i in _context.Interactions
                        join c in _context.Customers on i.customer_id equals c.customer_id
                        select new
                        {
                            interaction_id = i.interaction_id,
                            customer_id = i.customer_id,
                            first_name = c.first_name,
                            last_name = c.last_name,
                            interaction_type = i.interaction_type,
                            description = i.description,
                            interaction_date = i.interaction_date

                        });
            return View(data.ToList()); 
        }

    }
}

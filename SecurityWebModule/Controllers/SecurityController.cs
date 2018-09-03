using SecurityWebModule.Models;
using SecurityWebModule.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityWebModule.Controllers
{
    public class SecurityController : Controller
    {

        private SecurityService securityService;
        public SecurityController()
        {           
            this.securityService = new SecurityService();
        }

        // GET: Security
        public ActionResult Index()
        {
            return View(securityService.GetAll());
        }



        [HttpPost]
        [HandleError]
        public ActionResult Index(SecurityModel model)
        {
            if (ModelState.IsValid)
            {

                securityService.Insert(model);
                ModelState.Clear();
                
            }
            return RedirectToAction("Index");
        }

      
    }
}
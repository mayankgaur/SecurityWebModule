using NLog;
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
        Logger logger = LogManager.GetCurrentClassLogger();
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
        protected override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            // Redirect on error:
            filterContext.Result = RedirectToAction("Index", "Error");

            // OR set the result without redirection:
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Error/Index.cshtml"
            };
        }

    }
}
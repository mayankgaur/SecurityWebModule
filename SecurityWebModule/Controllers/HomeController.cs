using SecurityWebModule.Models;
using SecurityWebModule.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SecurityWebModule.Controllers
{
    public class HomeController : Controller
    {
        private LocateService locateService;
        

        public HomeController()
        {
            this.locateService = new LocateService();
          
        }
        public ActionResult Index()
        {
            return View(locateService.GetAll());
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }


        [HttpPost]
        [HandleError]
        public ActionResult Create(LocateModel model)
        {
            if (ModelState.IsValid)
            {

                locateService.Insert(model);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return PartialView("_Create",model);
        }

        public ActionResult Edit(int Id)
        {
            return PartialView("_Edit", locateService.GetbyID(Id));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [HandleError]
        public ActionResult Edit(LocateModel model)
        {

            if (ModelState.IsValid)
            {

                locateService.Update(model);
                ModelState.Clear();
                return RedirectToAction("Index");
            }
            return PartialView("_Edit",model);
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
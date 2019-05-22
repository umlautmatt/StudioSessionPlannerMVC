using Microsoft.AspNet.Identity;
using SessionPlanner.Models;
using SessionPlanner.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionPlanner.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var sessionTypeService = new SessionTypeService();
            var sessionTypeList = sessionTypeService.GetSessionTypes();

            ViewBag.SessionTypeID = new SelectList(sessionTypeList, "SessionTypeID", "Name");

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(SessionCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = GetSessionService();

            if (service.CreateSession(model))
            {
                return RedirectToAction("Index", "Session");
            }

            var sessionService = new SessionTypeService();
            var sessionTypeList = sessionService.GetSessionTypes();

            ViewBag.SessionTypeID = new SelectList(sessionTypeList, "SessionTypeID", "Name");

            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Studio()
        {
            return View();
        }

        // CREATE
        //public ActionResult Create()
        //{
        //    var sessionTypeService = new SessionTypeService();
        //    var sessionTypeList = sessionTypeService.GetSessionTypes();

        //    ViewBag.SessionTypeID = new SelectList(sessionTypeList, "SessionTypeID", "Name");

        //    return View();
        //}

        

        private SessionService GetSessionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            return service;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostawNaMilionAzure.Controllers
{
    public class AdminManageController : Controller
    {
        //Get: Main page 
        public ActionResult Index()
        {
            return View();
        }

        //Get Add Category
        public ActionResult AddCategory()
        {
            return View();
        }

        //Get Add question
        public ActionResult AddQuestion()
        {
            return View();
        }

        public ActionResult Category()
        {
            return View();
        }
    }
}
using PostawNaMilionAzure.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostawNaMilionAzure.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminManageController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        //Get: Main page 
        public ActionResult Index()
        {
            var lastRegisterUser = db.Users.Where(x => x.Id != "2f94a417-4a2d-4161-aa5a-fa20557490ff").
                                                    Take(5).ToList();
            ViewBag.IsRegisterUser = lastRegisterUser.Count > 0 ? true : false;
            return View(lastRegisterUser);
          
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
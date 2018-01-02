using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostawNaMilionAzure.Controllers
{
    public class AdminManageController : Controller
    {
        private IRepository<StepAddSubTotalValue> _stepAddSubTotalValue;
        private AzureContext _db = new AzureContext();

        public AdminManageController(IRepository<StepAddSubTotalValue> stepAddSubTotalValue)
        {
            _stepAddSubTotalValue = stepAddSubTotalValue;
        }

        [HttpGet]
        public ActionResult SetStepTotalValue()
        {
            ViewBag.CurrentTotalValue = ((StepAddSubTotalValueRepository)_stepAddSubTotalValue).GetLastValue().StepValue;
            return View();
        }

        [HttpPost]
        public ActionResult SetStepTotalValue(StepAddSubTotalValue stepAddSubTotalValue)
        {
            if (!ModelState.IsValid)
            {
                return View(stepAddSubTotalValue);
            }

            stepAddSubTotalValue.DateAdd = DateTime.Now;
            _stepAddSubTotalValue.Add(stepAddSubTotalValue);
            return RedirectToAction("SetStepTotalValue");
        }

        //Get: Main page 
        public ActionResult Index()
        {
            var lastRegisterUser = _db.Users.Where(x => x.Id != "3cd0cdd0-281d-490e-9731-1f1a46fed5e5").
                                                    Take(5).ToList();
            ViewBag.IsRegisterUser = lastRegisterUser.Count > 0 ? true : false;
            return View(lastRegisterUser);

        }
    }
}
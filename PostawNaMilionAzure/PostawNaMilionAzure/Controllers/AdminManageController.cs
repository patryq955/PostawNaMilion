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
    }
}
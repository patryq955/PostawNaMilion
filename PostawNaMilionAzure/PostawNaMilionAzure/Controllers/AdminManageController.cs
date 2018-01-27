using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.Repository;
using PostawNaMilionAzure.ViewModel;
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
        private IRepository<StepAddSubTotalValue> _stepAddSubTotalValue;
        private IExtendRepository<Game> _repositoryGame;
        private AzureContext _db = new AzureContext();

        public AdminManageController(IRepository<StepAddSubTotalValue> stepAddSubTotalValue,
            IExtendRepository<Game> repositoryGame)
        {
            _stepAddSubTotalValue = stepAddSubTotalValue;
            _repositoryGame = repositoryGame;
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
            var lastRegisterUser = _db.Users.Where(x => x.Id != "593ced2a-f41f-4483-9e62-731b531404b7").
                                                    Take(5).ToList();
            ViewBag.IsRegisterUser = lastRegisterUser.Count > 0 ? true : false;
            return View(lastRegisterUser);

        }

        [HttpGet]
        public ActionResult ValueGame(LastGameViewModel vM = null)
        {
            if (vM == null)
            {
                vM = new LastGameViewModel();

            }

            if (!ChechDate(vM.StarDate, vM.LastDate))
            {
                vM.StarDate = null;
                vM.LastDate = null;
                vM.CountGame = _repositoryGame.GetOverviewAll().ToList().Count();

            }
            else
            {
                Func<Game, bool> predicate = x => x.Date > DateTime.Parse(vM.StarDate) && x.Date < DateTime.Parse(vM.LastDate);
                vM.CountGame = _repositoryGame.GetOverviewAll(predicate).ToList().Count();
            }


            if (Request.IsAjaxRequest())
            {
                return PartialView("_ValueGame",vM);
            }


            return View(vM);
        }

        private bool ChechDate(string startDate, string endDate)
        {
            DateTime t1, t2;


            return DateTime.TryParse(startDate, out t1) && DateTime.TryParse(endDate, out t2);
        }
    }
}
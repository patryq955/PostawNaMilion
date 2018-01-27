using NLog;
using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostawNaMilionAzure.Controllers
{
    public class HomeController : Controller
    {
        private IExtendRepository<Game> _repositoryGame;

        public HomeController(IExtendRepository<Game> repositoryGame)
        {
            _repositoryGame = repositoryGame;

        }
        public ActionResult Index()
        {
            var lastTenGame = _repositoryGame.GetOverviewAll().OrderByDescending(x => x.Date).Take(10).ToList();
            return View(lastTenGame);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostawNaMilionAzure.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Game()
        {
            return View();
        }
        // GET: Game
        public ActionResult NewGame()
        {
            return View();
        }
    }
}
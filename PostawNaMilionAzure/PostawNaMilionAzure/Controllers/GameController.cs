using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostawNaMilionAzure.Controllers
{
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult NewGame()
        {
            return View();
        }
    }
}
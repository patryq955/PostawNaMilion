using Microsoft.AspNet.Identity;
using NLog;
using PostawNaMilionAzure.Exceptions;
using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.Repository;
using PostawNaMilionAzure.Utilties;
using PostawNaMilionAzure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostawNaMilionAzure.Controllers
{
    public class GameController : Controller
    {
        private IExtendRepository<Question> _questionRepository;
        private IRepository<Answer> _answerRepository;
        private IRepository<CategoryDict> _categoryDictRepository;
        private ISessionManager _sessionManager;
        private IExtendRepository<Game> _gameRepository;
        private GameManager _gameManager;
        private static Logger _log;

        public GameController(IExtendRepository<Question> questionRepository, IRepository<Answer> answerRepository,
         IRepository<CategoryDict> categoryDictRepository, ISessionManager sessionManager,
         IExtendRepository<Game> gameRepository,
         IRepository<StepAddSubTotalValue> stepAddSubTotalValueRepository)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _categoryDictRepository = categoryDictRepository;
            _sessionManager = sessionManager;
            _log = LogManager.GetCurrentClassLogger();
            _gameRepository = gameRepository;
            _gameManager = new GameManager(_sessionManager,
                                            _categoryDictRepository,
                                            _questionRepository,
                                            _answerRepository,
                                            _gameRepository,
                                            stepAddSubTotalValueRepository);
        }
        public ActionResult NewGame()
        {
            return View();
        }

        public ActionResult Game()
        {
            //try
            //{
                _gameManager.NewGame();
                var vM = _gameManager.GetCategory();
                vM.IsCategory = true;
                return View(vM);
            //}
            //catch(Exception e)
            //{
            //    _log.Info("Gracz " + User.Identity.Name + " - " + e.Message);
            //    return RedirectToAction("Error", "Home");
            //}

        }

        public ActionResult LostGame()
        {
            if (_sessionManager.Get<string>(GameCommon.ErrorMessage) != null)
            {
                _log.Info("Gracz " + User.Identity.Name + " - " + _sessionManager.Get<string>(GameCommon.ErrorMessage));
                return PartialView("ErrorPage", _sessionManager.Get<string>(GameCommon.ErrorMessage));
            }
            if (User.Identity.IsAuthenticated)
            {
                _gameManager.SaveResult(User.Identity.GetUserId());
            }
            return View();
        }


        public ActionResult WinGame()
        {
            if (User.Identity.IsAuthenticated)
            {
                _gameManager.SaveResult(User.Identity.AuthenticationType);
            }
            return View();
        }

        [HttpPost]
        public ActionResult GetQuestion(int categoryID)
        {
            try
            {
                var vM = _gameManager.GetQuestion(categoryID);
                vM.IsCategory = false;
                return PartialView("_Question", vM);
            }
            catch (GameException e)
            {
                _log.Info("Gracz " + User.Identity.Name + " - " + e.Message);
                return PartialView("_ErrorPage", e.Message);

            }

        }

        public ActionResult GetCategory()
        {
            try
            {
                var vM = _gameManager.GetCategory();
                vM.IsCategory = true;
                return PartialView("_Question", vM);
            }
            catch (GameException e)
            {
                _log.Info("Gracz " + User.Identity.Name + " - " + e.Message);
                return PartialView("_ErrorPage", e.Message);
            }

        }

        public int SendAnswer(int questionID, Dictionary<string, string> answers)
        {
            var vM = _gameManager.GetResultAnswer(questionID, answers);
            return (int)vM.TypeResultGame;
        }

        public ActionResult CheckResult(int result)
        {
            return result == (int)TypeResultGame.LostGame ?
                RedirectToAction("LostGame") :
                RedirectToAction("WinGame");
        }

        public ActionResult ErrorPage(string message)
        {
            return View(message);
        }

        [Authorize]
        public ActionResult LastGame()
        {
            Func<Game, bool> predicate = x => x.UserId == User.Identity.GetUserId();
            var allGame = _gameRepository.GetOverviewAll(predicate).OrderByDescending(x => x.Date).ToList();
            return View(allGame);
        }

    }
}
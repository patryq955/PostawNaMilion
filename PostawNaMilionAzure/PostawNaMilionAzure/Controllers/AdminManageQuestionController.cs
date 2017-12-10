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
    [Authorize(Roles = "Admin")]
    public class AdminManageQuestionController : BaseController
    {
        private IExtendRepository<Question> _questionRepository;
        private IRepository<Answer> _answerRepository;
        private IRepository<CategoryDict> _categoryDictRepository;


        public AdminManageQuestionController(IExtendRepository<Question> repositoryQuestion
            , IRepository<Answer> repositoryAnswer, IRepository<CategoryDict> repositoryCategoryDict
            , ITarget mapper
            ) : base(mapper)
        {
            _questionRepository = repositoryQuestion;
            _answerRepository = repositoryAnswer;
            _categoryDictRepository = repositoryCategoryDict;
        }

        [HttpGet]
        public ActionResult AddQuestion()
        {
            ViewBag.InfoAddQuestion = TempData["isAdd"] == null ? "" : "Pytanie zostało dodane";
            QuestionViewModel vM = new QuestionViewModel(_categoryDictRepository);
            vM.ActionName = "AddQuestion";
            return View(vM);
        }

        [HttpPost]
        public ActionResult AddQuestion(QuestionViewModel vM)
        {
            if (!ModelState.IsValid)
            {
                return View("AddQuestion", vM);
            }

            vM.AnswerList[vM.isCorrectNumber].IsCorrect = true;

            var question = _mapper.GetItem<QuestionViewModel, Question>(vM);
            question.Answer = new List<Answer>();
            foreach (var answer in vM.AnswerList)
            {
                question.Answer.Add(answer);
            }
            _questionRepository.Add(question);

            TempData["isAdd"] = "add";
            return RedirectToAction("AddQuestion");
        }

        [HttpGet]
        public ActionResult EditQuestion(int id)
        {
            QuestionViewModel vM = new QuestionViewModel(_categoryDictRepository);
            vM.ActionName = "EditQuestion";
            vM.Question = _questionRepository.GetIdAll(id);
            for(int i=0; i<vM.Question.Answer.Count(); i++)
            {
                vM.AnswerList[i] = _answerRepository.GetID(id);
            }
            return View(vM);
        }

        [HttpPost]
        public ActionResult EditQuestion(QuestionViewModel vM)
        {
            if(!ModelState.IsValid)
            {
                return View("EditQuestion", vM);
            }

            //vM.AnswerList = vM.AnswerList.Where(x => x.IsCorrect == true).Select(x => x.IsCorrect = false).ToArray();
            vM.AnswerList = vM.AnswerList.Select(x => { x.IsCorrect = false; return x; }).ToArray();
            vM.AnswerList[vM.isCorrectNumber].IsCorrect = true;


            return View();
        }



        public ActionResult Question (int categoryID)
        {
            Func<Question, bool> predicate = x => x.CategoryDictId == categoryID;
            var vM = _questionRepository.GetOverview(predicate).ToList();
            return View(vM);
        }


    }
}
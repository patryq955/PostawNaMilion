using PostawNaMilionAzure.Exception;
using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.Repository;
using PostawNaMilionAzure.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Utilties
{
    public class GameManager
    {
        private ISessionManager _sessionManager;
        private IRepository<CategoryDict> _categoryDictRepository;
        private IExtendRepository<Question> _questionRepository;
        private IRepository<Answer> _answerRepository;
        private IRepository<Game> _gameRepository;

        private Random _random;
        public GameManager(ISessionManager sessionManager, IRepository<CategoryDict> categoryDictRepository
            , IExtendRepository<Question> quetionRepository, IRepository<Answer> answerRepository
            , IRepository<Game> gameRepository)
        {
            _sessionManager = sessionManager;
            _categoryDictRepository = categoryDictRepository;
            _questionRepository = quetionRepository;
            _answerRepository = answerRepository;
            _gameRepository = gameRepository;
            _random = new Random();
        }

        public void NewGame()
        {
            _sessionManager.Set(GameCommon.NumberQuestion, 1);
            _sessionManager.Set(GameCommon.SumValue, GameCommon.StartSumValue);
            _sessionManager.Set(GameCommon.ListAnswer, new List<int>());
            _sessionManager.Set<string>(GameCommon.ErrorMessage, null);
        }

        public bool CheckAnswer(int questionID, int answerID)
        {
            Func<Answer, bool> predicate = x => x.Id == answerID && x.QuestionId == questionID && x.IsCorrect == true;
            var answer = ((AnswerRepository)_answerRepository).GetID(predicate);

            return answer != null;
        }

        public TypeResultGame AnswerOnQuestion(int questionID, Dictionary<string, string> answers)
        {
            var sumValue = GetSumValue();
            var numberQuestion = GetNumberQuestion();
            var listAnswer = _sessionManager.Get<List<int>>(GameCommon.ListAnswer);
            if (answers.ToList().Sum(x => float.Parse(x.Value)) > sumValue)
            {
                throw new GameException("Błedna suma");
            }
            var tmp = _sessionManager.Get<Int32>(GameCommon.ControlQuestionID);
            if (questionID != _sessionManager.Get<Int32>(GameCommon.ControlQuestionID))
            {
                throw new GameException("Id pytania są niezgodne");
            }

            sumValue = 0;
            answers.ToList().ForEach(x =>
            {
                sumValue += CheckAnswer(questionID, Int32.Parse(x.Key)) ? float.Parse(x.Value) : 0;
            });

            //Save session
            listAnswer.Add(questionID);
            _sessionManager.Set(GameCommon.SumValue, sumValue);
            _sessionManager.Set(GameCommon.ListAnswer, listAnswer);
            _sessionManager.Set(GameCommon.NumberQuestion, ++numberQuestion);

            if (sumValue == 0)
            {
                return TypeResultGame.LostGame;
            }


            return numberQuestion > 8 ? TypeResultGame.WinGame : TypeResultGame.NextQuestion;
        }

        public GameViewModel GetResultAnswer(int questionID, Dictionary<string, string> answers)
        {
            var vM = new GameViewModel();

            try
            {
                vM.TypeResultGame = AnswerOnQuestion(questionID, answers);
                vM.NumberQuestion = GetNumberQuestion();
                vM.SumValue = GetSumValue();
            }
            catch (GameException e)
            {
                vM.TypeResultGame = TypeResultGame.LostGame;
                _sessionManager.Set(GameCommon.ErrorMessage, e.Message);
            }


            return vM;
        }

        public GameViewModel GetCategory(GameViewModel vM = null)
        {
            if (vM == null)
            {
                vM = new GameViewModel();
            }
            vM.CategoryDict = RandCategory();
            vM.NumberQuestion = GetNumberQuestion();
            vM.SumValue = GetSumValue();
            return vM;
        }

        public GameViewModel GetQuestion(int categoryID)
        {
            var vM = new GameViewModel();
            vM.Question = RandQuestion(categoryID);
            vM.NumberQuestion = GetNumberQuestion();
            vM.SumValue = GetSumValue();

            return vM;
        }

        public void SaveResult(string user)
        {
            var game = new Game();
            game.Balance = GetSumValue();
            game.Date = DateTime.Now;
            game.StageEnd = GetNumberQuestion() - 1;
            game.UserId = user;
            _gameRepository.Add(game);
        }

        private List<CategoryDict> RandCategory()
        {
            int randomIndex = 0;
            var confirmCategoryID = GetQuestionID();
            Func<CategoryDict, bool> predicate = x => confirmCategoryID.Contains(x.Id) && !x.IsHidden;

            var categories = _categoryDictRepository.GetOverview(predicate).ToList();
            List<CategoryDict> twoCategory = new List<CategoryDict>();

            if (categories.Count < 2)
            {
                throw new GameException("Za mało kategorii w systemie");
            }
            for (int i = 0; i < 2; i++)
            {
                randomIndex = _random.Next(0, categories.Count);
                twoCategory.Add(categories[randomIndex]);
                categories.RemoveAt(randomIndex);
            }

            return twoCategory;
        }

        private Question RandQuestion(int categoryID)
        {
            //pamietac o sprawdzaniu czy istnieje kategoria z takim ID
            int randomIndex = 0;
            int lvlQuestion = GetLvlQuestion();
            var questionWithGame = GetQuestionWithGame();
            Func<Question, bool> predicate = x => x.CategoryDictId == categoryID && (int)x.Level == lvlQuestion;
            var questions = _questionRepository.GetOverviewAll(predicate).ToList();
            Question questionReturn = new Question();

            while (true)
            {
                randomIndex = _random.Next(0, questions.Count);
                var result = questionWithGame.Find(x => x == questions[randomIndex].Id);
                if (result == 0)
                {
                    questionReturn = questions[randomIndex];
                    break;
                }
            }

            _sessionManager.Set(GameCommon.ControlQuestionID, questionReturn.Id);
            return questionReturn;

        }

        #region Helpers



        /// <summary>
        /// All category with question more than 2 but without question in List _questionWithGame
        /// </summary>
        private List<int> GetQuestionID()
        {
            int lvlQuestion = GetLvlQuestion();
            var questionWithGame = GetQuestionWithGame();
            Func<Question, bool> predicate = t2 => !questionWithGame.Any(t1 => t1 == t2.Id);
            var tmpQuestions = _questionRepository.GetOverview(predicate).ToList();
            tmpQuestions = tmpQuestions.Where(x => (int)x.Level == lvlQuestion && !x.IsHidden).ToList();
            return tmpQuestions
                .GroupBy(x => x.CategoryDictId)
                .Where(x => x.Count() > 2)
                .Select(x => x.Key).ToList();

        }

        private int GetNumberQuestion()
        {
            return _sessionManager.Get<int>(GameCommon.NumberQuestion);
        }

        private float GetSumValue()
        {
            return _sessionManager.Get<float>(GameCommon.SumValue);
        }

        private int GetLvlQuestion()
        {
            return _sessionManager.Get<int>(GameCommon.NumberQuestion) > 4 ? 2 : 1;
        }

        private List<int> GetQuestionWithGame()
        {
            return _sessionManager.Get<List<int>>(GameCommon.ListAnswer);
        }
        #endregion
    }
}
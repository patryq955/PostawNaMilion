using PostawNaMilionAzure.Models;
using PostawNaMilionAzure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.ViewModel
{
    public class QuestionViewModel
    {
        public Question Question { get; set; }

        public int isCorrectNumber { get; set; }

        public Answer[] AnswerList { get; set; }

        public string ActionName { get; set; }

        public IEnumerable<LevelToSelectList> LevelDropDownList { get; set; }

        public IEnumerable<CategoryDict> CategoryListDropDownList { get; set; }

        private IRepository<CategoryDict> _repositoryCategoryDict;

        public QuestionViewModel()
        {

        }

        public QuestionViewModel(IRepository<CategoryDict> repositoryCategoryDict)
        {
            _repositoryCategoryDict = repositoryCategoryDict;
            LoadDropDownList();
            AnswerList = new Answer[4];
        }


        private void LoadDropDownList()
        {
            CategoryListDropDownList = _repositoryCategoryDict.GetOverview();
            LevelDropDownList = from Level e in Enum.GetValues(typeof(Level))
                                select new LevelToSelectList
                                {
                                    ID = (int)e,
                                    Name = e.ToString()
                                };

        }

    }

    public class LevelToSelectList
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
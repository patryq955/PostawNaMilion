using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.ViewModel
{
    public class QuestionAnserView
    {
        public int Id { get; set; }
        public String Contents { get; set; }
        public int Level { get; set; }
        public int CategoryDictId { get; set; }
        public int AnswerId { get; set; }
        public String ContentsAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}
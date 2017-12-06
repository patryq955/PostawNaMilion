using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class QuestionRepository
    {
        public static List<Question> Get()
        {
            using (var db = new AzureContext())
                return db.Question.ToList();
        }

        public static Question GetById(int Id)
        {
            using (var db = new AzureContext())
                return db.Question.Where(x => x.Id == Id).FirstOrDefault();
        }

    }
}
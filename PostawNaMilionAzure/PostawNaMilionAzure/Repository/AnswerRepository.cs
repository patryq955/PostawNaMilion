using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class AnswerRepository
    {
        public static List<Answer> Get()
        {
            using (var db = new AzureContext())
                return db.Answer.ToList();
        }

        public static Answer GetById(int Id)
        {
            using (var db = new AzureContext())
                return db.Answer.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
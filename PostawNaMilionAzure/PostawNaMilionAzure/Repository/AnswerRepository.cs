using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class AnswerRepository : IRepository<Answer>
    {
        AzureContext db;
        public AnswerRepository()
        {
            db = new AzureContext();
        }
        public void Add(Answer entity)
        {
            db.Answer.Add(entity);
            Save();
        }

        public void Delete(Answer entity)
        {
            db.Answer.Remove(entity);
            Save();
        }

        public Answer GetID(int Id)
        {
            return db.Answer.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<Answer> GetOverview(Func<Answer, bool> predicate = null)
        {
            if (predicate == null)
            {
                return db.Answer;
            }
            return db.Answer.Where(predicate);
        }

        private void Save()
        {
            db.SaveChanges();
        }

        public void Update(Answer entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            Save();   
        }
    }
}
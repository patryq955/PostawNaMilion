using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class QuestionRepository : IExtendRepository<Question>
    {
        AzureContext db;

        public QuestionRepository()
        {
            db = new AzureContext();
        }

        public void Add(Question entity)
        {
            db.Question.Add(entity);
            Save();
        }

        public void Delete(Question entity)
        {
            db.Question.Remove(entity);
            Save();
        }

        public Question GetID(int id)
        {
            return db.Question.Where(x => x.Id == id).FirstOrDefault();
        }

        public Question GetIdAll(int id)
        {
            return db.Question.Include(x =>x.Answer).Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Question> GetOverview(Func<Question, bool> predicate = null)
        {
            if (predicate == null)
            {
                return db.Question;
            }

            return db.Question.Where(predicate);
        }

        public IEnumerable<Question> GetOverviewAll(Func<Question, bool> predicate = null)
        {
            if (predicate == null)
            {
                return db.Question.Include(x => x.Answer);
            }

            return db.Question.Include(x => x.Answer).Where(predicate);
        }

        public void Update(Question entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            Save();
        }

        private void Save()
        {
            db.SaveChanges();
        }
    }
}
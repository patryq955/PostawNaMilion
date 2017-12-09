using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class KnowledgeAreaRepository : IRepository<KnowledgeArea>
    {
        AzureContext db;
        public KnowledgeAreaRepository()
        {
            db = new AzureContext();
        }

        public void Add(KnowledgeArea entity)
        {
            db.KnowledgeArea.Add(entity);
            Save();
        }

        public void Delete(KnowledgeArea entity)
        {
            db.KnowledgeArea.Remove(entity);
            Save();
        }

        public KnowledgeArea GetID(int Id)
        {
            return db.KnowledgeArea.Where(x => x.Id == Id).FirstOrDefault();
        }

        public IEnumerable<KnowledgeArea> GetOverview(Func<KnowledgeArea, bool> predicate = null)
        {
            if (predicate == null)
            {
                return db.KnowledgeArea;
            }

            return db.KnowledgeArea.Where(predicate);
        }

        public void Update(KnowledgeArea entity)
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
using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class KnowledgeAreaRepository
    {

        public static List<KnowledgeArea> Get()
        {
            using (var db = new AzureContext())
                return db.KnowledgeArea.ToList();
        }

        public static KnowledgeArea  GetById(int Id)
        {
            using (var db = new AzureContext())
                return db.KnowledgeArea.Where(x=>x.Id == Id).FirstOrDefault();
        }

        public static void CreateOrUpdate(KnowledgeArea  knowledgeArea)
        {
            using (var db = new AzureContext()) {
                if (knowledgeArea.Id != 0)
                {
                    db.Entry(knowledgeArea).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                else
                {
                    db.KnowledgeArea.Add(knowledgeArea);
                    db.SaveChanges();
                }
            }
        }

        public static void Delete(int Id)
        {
            var delObject = GetById(Id);
            if(delObject != null)
            using (var db = new AzureContext())
            {
                db.KnowledgeArea.Remove(delObject);
                db.SaveChanges();
            }
        }

    }
}
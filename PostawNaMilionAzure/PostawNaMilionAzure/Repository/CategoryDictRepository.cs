using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class CategoryDictRepository : IRepository<CategoryDict>
    {
        AzureContext db;
        public CategoryDictRepository()
        {
            db = new AzureContext();
        }
        public void Add(CategoryDict entity)
        {
            db.CategoryDict.Add(entity);
            Save();
        }

        public void Delete(CategoryDict entity)
        {
            db.CategoryDict.Remove(entity);
            Save();
        }

        public CategoryDict GetID(int id)
        {
            return db.CategoryDict.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<CategoryDict> GetOverview(Func<CategoryDict, bool> predicate = null)
        {
            if (predicate == null)
            {
                return db.CategoryDict;
            }

            return db.CategoryDict.Where(predicate);
        }

        public void Update(CategoryDict entity)
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
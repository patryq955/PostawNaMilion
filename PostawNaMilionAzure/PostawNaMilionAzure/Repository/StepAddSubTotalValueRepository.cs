using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class StepAddSubTotalValueRepository : IRepository<StepAddSubTotalValue>
    {
        AzureContext db;
        public StepAddSubTotalValueRepository()
        {
            db = new AzureContext();
        }

        public void Add(StepAddSubTotalValue entity)
        {
            db.StepAddSubTotalValue.Add(entity);
            Save();
        }

        public void Delete(StepAddSubTotalValue entity)
        {
            db.StepAddSubTotalValue.Remove(entity);
            Save();
        }

        public StepAddSubTotalValue GetID(int id)
        {
            return db.StepAddSubTotalValue.Where(x => x.Id == id).FirstOrDefault();
        }

        public StepAddSubTotalValue GetLastValue()
        {
            var step = db.StepAddSubTotalValue.OrderByDescending(x => x.DateAdd).FirstOrDefault();
            return step == null ? new StepAddSubTotalValue { Id = 25000 } : step;

        }

        public IEnumerable<StepAddSubTotalValue> GetOverview(Func<StepAddSubTotalValue, bool> predicate = null)
        {
            if (predicate == null)
            {
                return db.StepAddSubTotalValue;
            }

            return db.StepAddSubTotalValue.Where(predicate);
        }

        public void Update(StepAddSubTotalValue entity)
        {
            db.Entry(entity).State = EntityState.Modified;
        }

        private void Save()
        {
            db.SaveChanges();
        }
    }
}
using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class GameRepository : IRepository<Game>
    {
        AzureContext db;
        public GameRepository()
        {
            db = new AzureContext();
        } 
        public void Add(Game entity)
        {
            db.Game.Add(entity);
            Save();
        }

        public void Delete(Game entity)
        {
            db.Game.Remove(entity);
            Save();
        }

        public Game GetID(int id)
        {
            return db.Game.Where(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Game> GetOverview(Func<Game, bool> predicate = null)
        {
            if (predicate == null)
            {
                return db.Game;
            }

            return db.Game.Where(predicate);
        }

        public void Update(Game entity)
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
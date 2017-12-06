using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Repository
{
    public class CategoryDictRepository
    {
        public static List<CategoryDict> Get()
        {
            using (var db = new AzureContext())
                return db.CategoryDict.ToList();
        }

        public static CategoryDict GetById(int Id)
        {
            using (var db = new AzureContext())
                return db.CategoryDict.Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
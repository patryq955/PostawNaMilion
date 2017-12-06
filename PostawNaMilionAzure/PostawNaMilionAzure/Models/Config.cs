using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Models
{
    public class AzureContext : DbContext
    {

        public AzureContext() : base("DefaultConnection")
        {

        }

        public DbSet<KnowledgeArea> KnowledgeArea { get; set; }
        public DbSet<CategoryDict> CategoryDict { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Question> Question { get; set; }


    }
}
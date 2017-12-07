﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.Models
{
    public class AzureContext : DbContext 
    {

        public AzureContext() : base ("DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<AzureContext>(null);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<KnowledgeArea> KnowledgeArea { get; set; }
        public DbSet<CategoryDict> CategoryDict { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<UserRate> UserRate { get; set; }
        public DbSet<GameStep> GameStep { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Role> Role { get; set; }
    }
}
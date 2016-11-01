using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WordPractice.Model.Models;

namespace WordPractice
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<German> GermanTable { get; set; }
    }
}
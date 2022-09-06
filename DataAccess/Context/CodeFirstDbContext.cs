using DataAccess.Mapping;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class CodeFirstDbContext : DbContext
    {
        public CodeFirstDbContext() : base("Server = FURKANDUZYOL\\MSSQLSERVERFD; Database=KD12CodeFirtsAppTekrarDB;Trusted_Connection=True")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<CodeFirstDbContext>());
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<School> Schools { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Birazdan yapacağım database düzenleme işlemlerini buraya ekleyeceğim.
            modelBuilder.Configurations.Add(new TeacherMapping());
            modelBuilder.Configurations.Add(new SchoolMapping());
        }

    }
}

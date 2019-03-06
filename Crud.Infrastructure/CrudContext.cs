using Crud.Domain.Entities;
using Crud.Infrastructure.Repositories.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Crud.Infrastructure
{
    public class CrudContext : DbContext, ICrudContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dataFilename = Path.GetFullPath(@"..\App_Data\CrudDb.mdf");

            // optionsBuilder.UseSqlServer($@"Data Source=(LocalDb)\v11.0;AttachDbFilename={dataFilename};Initial Catalog=CrudDb;Integrated Security=True;MultipleActiveResultSets=True");
            optionsBuilder.UseSqlServer($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={dataFilename};Initial Catalog=CrudDb;Integrated Security=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
        }
    }
}

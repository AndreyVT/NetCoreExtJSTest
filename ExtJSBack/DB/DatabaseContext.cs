using ExtJSBack.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ExtJSBack.DB
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlite("Filename:myTestDB.db");
            optionsBuilder.UseSqlite("Data Source=myTestDB.db");
        }
    }
}

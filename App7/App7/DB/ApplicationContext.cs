using App7.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace App7.DB
{
    public class ApplicationContext : DbContext
    {
        private string _dbName;

        public DbSet<Book> Books { get; set; }

        public ApplicationContext(string dbName)
        {
            _dbName = dbName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\usersdb;Database=efbasicsappdb;Trusted_Connection=True;");
        }


    }
}

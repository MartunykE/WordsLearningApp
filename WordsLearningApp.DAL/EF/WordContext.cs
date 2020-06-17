using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WordsLearningApp.DAL.Models;

namespace WordsLearningApp.DAL.EF
{
    class WordContext : DbContext
    {
        //check connection string 
        public WordContext(DbContextOptions<WordContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<User> Users { get; set; }

    }

}
